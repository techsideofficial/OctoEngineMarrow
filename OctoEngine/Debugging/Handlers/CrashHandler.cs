using System.Diagnostics;
using Miku;
using Starlight;
using OctoEngine.Utils;

namespace OctoEngine.Debugging
{
    public class CrashHandler
    {
        public static string FormatStackTraceExecutingPath(StackTrace stack)
        {
            string finalTrace = "\n\n";
            foreach (StackFrame frame in stack.GetFrames())
            {
                var method = frame.GetMethod();
                string methodName = method.Name;
                string className = method.DeclaringType?.FullName ?? "[Unknown Class]";
                string fileName = frame.GetFileName() ?? "[Unknown File]";
                int lineNumber = frame.GetFileLineNumber();

                finalTrace += $"{className}.{methodName} (at {fileName}:{lineNumber})\n";
            }

            return finalTrace;
        }

        public static void InitiateCrash(string crashMessage)
        {
            string CrashExeName = "InkTrace.exe";

            Logging.LogCrash(crashMessage); // Log a specified message as a crash.

            StarlightFormat starlight = new()
{
    AppName = StaticGameData.AppName,
    AppVersion = StaticGameData.AppVersion,
    CrashMessage = File.ReadAllText(TempStorage.ReadTempValue("currentlogpath")),
    CrashLogPath = TempStorage.ReadTempValue("currentlogpath"),
    CrashType = "0"
};

            LaunchProcess(
                Path.Combine(CommonVars.ApplicationPath, CrashExeName),
                StarlightSerializer.EncodeStarlight(starlight)
                );

            Environment.Exit(0); // Check this if there is weird crashing. Don't know if this exits InkTrace too.
        }

        private static void LaunchProcess(string appPath, string args) // Process launch helper.
        {
            ProcessStartInfo appStartInfo = new()
{
    FileName = appPath,
    Arguments = args,
    UseShellExecute = false,
    CreateNoWindow = true,
    RedirectStandardOutput = false,
    RedirectStandardError = false
};

            Process appProc = Process.Start(appStartInfo);
        }
    }
}
