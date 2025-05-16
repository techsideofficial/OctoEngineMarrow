using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine
{
    public partial class Deeplink // Experimental dogshit - do not touch this code, it will bite!
    {
        private static CancellationTokenSource cancellationTokenSource;
        private static Task pipeServerTask;
        private static Action<string> deepLinkCallback;

        public static void StartListening(Action<string> callback)
        {
            deepLinkCallback = callback;
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            pipeServerTask = Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    using (NamedPipeServerStream pipeServer = new("MyAppPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message))
                    {
                        try
                        {
                            pipeServer.WaitForConnectionAsync(cancellationToken).Wait(cancellationToken);

                            using (StreamReader reader = new(pipeServer))
                            {
                                string message = reader.ReadLine();
                                if (!string.IsNullOrEmpty(message) && deepLinkCallback != null)
                                {
                                    deepLinkCallback(message);
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // Graceful exit on cancellation
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Pipe error: {ex.Message}");
                        }
                    }
                }
            }, cancellationToken);
        }

        public static void SendDeepLink(string message)
        {
            try
            {
                using (NamedPipeClientStream pipeClient = new(".", "MyAppPipe", PipeDirection.Out))
                {
                    pipeClient.Connect(2000); // Wait for up to 2 seconds
                    using (StreamWriter writer = new(pipeClient))
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send message: {ex.Message}");
            }
        }

        public static void StopListening()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                try
                {
                    pipeServerTask?.Wait(); // Wait for the task to complete
                }
                catch (AggregateException ex)
                {
                    foreach (var inner in ex.InnerExceptions)
                    {
                        Console.WriteLine($"Error during shutdown: {inner.Message}");
                    }
                }
                finally
                {
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = null;
                }
            }
        }
    }
}