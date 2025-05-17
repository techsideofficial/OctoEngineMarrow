using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OctoEngine.MarrowFramework.Internal;

// someone please test this shit and tell me if it works
namespace OctoEngine.MarrowFramework.Console
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class OMCommandAttribute : Attribute
    {
        public string CommandName { get; }

        public OMCommandAttribute(string commandName)
        {
            CommandName = commandName;
        }
    }

    internal class OMConsoleServer
    {
        private static HttpListener _httpListener;
        private static readonly Dictionary<string, MethodInfo> CommandRegistry = new();
        private static readonly ConcurrentBag<WebSocket> ConnectedClients = new();

        public static void RegisterCommands()
        {
            var methods = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                .Where(m => m.GetCustomAttribute<OMCommandAttribute>() != null);

            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<OMCommandAttribute>();
                if (attribute != null)
                {
                    CommandRegistry[attribute.CommandName] = method;
                }
            }
        }

        public static async Task StartServer(string urlPrefix)
        {
            RegisterCommands();

            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(urlPrefix);
            _httpListener.Start();
            ModLog.LogMessage($"WebSocket server started at {urlPrefix}");

            while (true)
            {
                var context = await _httpListener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    var webSocketContext = await context.AcceptWebSocketAsync(null);
                    _ = HandleConnection(webSocketContext.WebSocket);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        private static async Task HandleConnection(WebSocket webSocket)
        {
            ConnectedClients.Add(webSocket);
            ModLog.LogMessage("Console connected.");
            var buffer = new byte[1024 * 4];

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        ModLog.LogMessage("Console disconnected.");
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                        break;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    ModLog.LogMessage($"Received: {message}");

                    // Execute code based on the command
                    var response = ExecuteCommand(message);

                    // Send response back to the client
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    await webSocket.SendAsync(new ArraySegment<byte>(responseBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                ModLog.LogMessage($"Error: {ex.Message}");
            }
            finally
            {
                ConnectedClients.TryTake(out _);
                webSocket.Dispose();
            }
        }

        private static string ExecuteCommand(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "No command provided.";

            var commandName = parts[0];
            var parameters = parts.Skip(1).ToArray();

            if (CommandRegistry.TryGetValue(commandName, out var method))
            {
                try
                {
                    var result = method.Invoke(null, new object[] { parameters });
                    return result?.ToString() ?? "Command executed successfully.";
                }
                catch (Exception ex)
                {
                    return $"Error executing command: {ex.Message}";
                }
            }

            return $"Unknown command: {commandName}";
        }

        public static void BroadcastMessage(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            foreach (var client in ConnectedClients)
            {
                if (client.State == WebSocketState.Open)
                {
                    _ = client.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
