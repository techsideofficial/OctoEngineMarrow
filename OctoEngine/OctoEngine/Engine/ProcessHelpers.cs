using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OctoEngine.Engine
{
    internal class ProcessHelpers
    {
        public static void LaunchProgram(string path, bool quitGame)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            string text = string.Empty;
            for (int i = 0; i < commandLineArgs.Length; i++)
            {
                text += commandLineArgs[i];
                if (i < commandLineArgs.Length - 1)
                {
                    text += " ";
                }
            }
            PlayerPrefs.Save();
            Process.Start(path, text).WaitForExit(5000);
            if (quitGame) Application.Quit();
        }
    }
}
