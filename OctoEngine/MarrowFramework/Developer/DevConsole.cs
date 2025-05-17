using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Marrow.Utilities;
using NEP.NEDebug.Console;
using OctoEngine.MarrowFramework.Base;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Developer
{
    // why
    internal class DevConsole
    {
#if DEBUG
        [NEConsoleCommand("audio.reset")]
#endif
        public static void AudioReset()
        {
            List<AudioSystem> audioSystems = GameObject.FindObjectsOfType<AudioSystem>().ToList();

            foreach (AudioSystem audioSystem in audioSystems)
            {
                if (!audioSystem.gameObject.ObjectPath().Contains("//-----REQUIRED"))
                {
                    audioSystem.StopAllAudio();
                }
            }
        }
    }
}
