namespace OctoEngine.MarrowFramework.Internal
{
    public class ModLog
    {
        internal static void CreateSessionLog()
        {
            Utils.Logging.CreateSessionLog(false);
        }

        public static void LogMessage(string message)
        {
            Utils.Logging.LogMessage(message);
            OCppConstants.logger.Msg(message);
            MarrowFramework.Console.OMConsoleServer.BroadcastMessage($"[INFO] {message}");
        }

        public static void LogWarn(string message)
        {
            Utils.Logging.LogWarn(message);
            OCppConstants.logger.Warning(message);
            MarrowFramework.Console.OMConsoleServer.BroadcastMessage($"[WARN] {message}");
        }

        public static void LogError(string message)
        {
            Utils.Logging.LogError(message);
            OCppConstants.logger.Error(message);
            MarrowFramework.Console.OMConsoleServer.BroadcastMessage($"[ERROR] {message}");
        }
    }
}
