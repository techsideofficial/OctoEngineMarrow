using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Miku;

namespace OctoEngine.Utils
{
    public class CommonVars // Provides quick access to common engine directories.
    {
        // Base path config. Changing this will change the location where all engine files are stored.
        public static string ApplicationPath
        {
            get
            {
                if (StaticGameData.CustomBasePath != "")
                {
                    return StaticGameData.CustomBasePath;
                } 
                else
                {
                    return AppDomain.CurrentDomain.BaseDirectory;
                }
            }
            set
            {

            }
        }

        public readonly static string DataDir = Path.Combine(ApplicationPath, "OctoEngine");

        public readonly static string GameDataDir = Path.Combine(ApplicationPath, "Data");

        public readonly static string ConfigDir = Path.Combine(DataDir, "Config");

        public readonly static string SettingsFilePath = Path.Combine(ConfigDir, "OctoApp.xml"); // Default config.

        public readonly static string PluginsDir = Path.Combine(DataDir, "Plugins");
    }
}
