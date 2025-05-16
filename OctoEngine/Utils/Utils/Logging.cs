namespace OctoEngine.Utils
{
    public partial class Logging
    {
        public static Logging loggingOcto = new();

        private static bool LogToConsole()
        {
            return bool.Parse(TempStorage.ReadTempValue("logtoconsole"));
        }

        public static void CreateSessionLog(bool logToConsole) // Must be run on app start with RegisterApp().
        {
            string CurrDate = String.Concat(
                DateTime.Now.Date.Year,
                DateTime.Now.Date.Month,
                DateTime.Now.Date.Day
                );

            string CurrTime = String.Concat(
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second
                );

            string LogFNameFormat = String.Concat(
                "OctoApp_",
                CurrDate,
                "-",
                CurrTime,
                ".log"
                );

            string LogFilePath = Path.Combine(CommonVars.DataDir, "Logs", LogFNameFormat);

            TempStorage.WriteTempValue("currentlogpath", LogFilePath);
            TempStorage.WriteTempValue("logtoconsole", logToConsole.ToString());

            File.WriteAllText(LogFilePath, "[Log] Create\n");
        }

        public static void LogMessage(string message)
        {
            string tempMsg = String.Concat("[Log] ", message);
            File.AppendAllText(
                TempStorage.ReadTempValue("currentlogpath"),
                tempMsg + "\n"
            );

            if (LogToConsole())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(tempMsg);
                Console.ResetColor();
            }

            loggingOcto.OnLogMessage(String.Concat("[Log] ", message));
        }

        public static void LogWarn(string message)
        {
            string tempMsg = String.Concat("[Warn] ", message);
            File.AppendAllText(
                TempStorage.ReadTempValue("currentlogpath"),
                tempMsg + "\n"
            );

            if (LogToConsole())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(tempMsg);
                Console.ResetColor();
            }

            loggingOcto.OnLogWarn(String.Concat("[Warn] ", message));
        }

        public static void LogError(string message)
        {
            string tempMsg = String.Concat("[Error] ", message);
            File.AppendAllText(
                TempStorage.ReadTempValue("currentlogpath"),
                tempMsg + "\n"
            );

            if (LogToConsole())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(tempMsg);
                Console.ResetColor();
            }

            loggingOcto.OnLogError(String.Concat("[Error] ", message));
        }

        internal static void LogDevDebug(string message) // Only use this for internal engine stuff.
        {
            string tempMsg = String.Concat("[Dev] ", message);
            File.AppendAllText(
                TempStorage.ReadTempValue("currentlogpath"),
                tempMsg + "\n"
            );

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(tempMsg);
            Console.ResetColor();
        }

        public static void LogCrash(string message) // Only use this for crash handler.
        {
            string tempMsg = String.Concat("[Crash] ", message);
            File.AppendAllText(
                TempStorage.ReadTempValue("currentlogpath"),
                tempMsg + "\n"
            );

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(tempMsg);
            Console.ResetColor();

        }

        /*
        public static void CreateCrashLog() // Must be run on app start with RegisterApp().
        {
            string CurrDate = String.Concat(
                DateTime.Now.Date.Year,
                DateTime.Now.Date.Month,
                DateTime.Now.Date.Day
                );

            string CurrTime = String.Concat(
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second
                );

            string LogFNameFormat = String.Concat(
                "OctoApp_Crash_",
                CurrDate,
                "-",
                CurrTime,
                ".log"
                );

            string LogFilePath = Path.Combine(CommonVars.DataDir, "Crash", LogFNameFormat);

            TempStorage.WriteTempValue("currentlogpath", LogFilePath);

            File.WriteAllText(LogFilePath, "[Log] Create");
        }
        */

        // ToDo: Add crash logging, and generation of crash dump.
        // If crash occurs, pass control to engine bug reporter (ToDo).
    }
}
