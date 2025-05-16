using System.Diagnostics;

namespace OctoEngine.Debugging.Exceptions
{
    public class NotImplemented : NotImplementedException
    {
        public NotImplemented()
        {
            StackTrace stackTrace = new(true);
            //CrashHandler.InitiateCrash(CrashHandler.StackTraceGen()); // Do not use (buggy)

            // CrashHandler.InitiateCrash("\n----EXCEPTION: NOT IMPLEMENTED----\n\nMETHOD: " + stackTrace.GetFrame(1).GetMethod().Name);

            CrashHandler.InitiateCrash(CrashHandler.FormatStackTraceExecutingPath(stackTrace));
        }
    }
}
