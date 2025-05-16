using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Developer
{
    public class DebugUI : MonoBehaviour
    {
        private void OnGUI()
        {
            // Make a background box
            GUI.Box(new Rect(10, 10, 100, 60), "OctoEngine Debug");

            if (GUI.Button(new Rect(20, 40, 80, 20), "Reset Audio"))
            {
                Developer.DevConsole.AudioReset();
            }
        }

#if MELONLOADER
        public DebugUI(IntPtr ptr) : base(ptr) { }
#endif
    }
}
