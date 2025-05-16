using System;
using System.Runtime.InteropServices;

namespace OctoEngine
{
    internal class EntryPoint
    {
        // Allocate a console if one doesn't exist
        // [DllImport("kernel32.dll")]
        // private static extern bool AllocConsole();

        static EntryPoint()
        {
            // AllocConsole(); // Opens a console window for output
            // Console.WriteLine("Hello World");
        }

        // A test method to confirm the DLL is working
        internal static void Test()
        {
            // Console.WriteLine("DLL Test Method Called!");
        }
    }
}
