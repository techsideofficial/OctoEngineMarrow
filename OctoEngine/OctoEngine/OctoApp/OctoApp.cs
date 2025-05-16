using OctoEngine.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.Debugging;
using OctoEngine.Networking;
using Miku;
using OctoEngine.Formats;
using ConfigCat.Client;
using OctoEngine.Engine;

namespace OctoEngine
{
    public class OctoApp // Contains initialization, setup, and helpers for processes using the engine.
    {
        public static void RegisterApplication(bool useConfigCat, List<string> GameDataSubdirs, bool LogToConsole)
        {
            // Begin Initialization
            GenerateEngineFilesystem();
            GenerateGameFilesystem(GameDataSubdirs);
            Utils.Logging.CreateSessionLog(LogToConsole);
            // End Initialization

            try
            {
                Logging.LogMessage("Initialized Miku.dll for app: " + Miku.StaticGameData.AppName);
            }
            catch
            {
                CrashHandler.InitiateCrash( // This code may be completely fucking useless.
                    "Miku.dll could not be found.\n" +
                    "Please ensure you have followed the setup guide for project configuration."
                    );
            }

            Utils.Logging.LogMessage(String.Concat("Registered app with name: ", Miku.StaticGameData.AppName));
            Utils.Logging.LogMessage(String.Concat("Setting up..."));

            // Begin Setup Code
            CreateEngineConfig(Miku.StaticGameData.AppName);

            string eulaVerPath = Path.Combine(CommonVars.ConfigDir, "legalversion.oc");
            File.WriteAllText(eulaVerPath, "0");
            // End Setup Code

            Utils.Logging.LogMessage(String.Concat("Set up complete! Starting App Domain..."));
            Utils.Logging.LogMessage(String.Concat("App Domain Started"));

            if (useConfigCat)
            {
                if (!Flags.GetFlag("EngineEnabled", true, "default"))
                {
                    Utils.Logging.LogError("ENGINE DISABLED");
                    Environment.Exit(0);
                }
            }
        }

        public static void LaunchProcess(string appPath, string args) // Process launch helper.
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

        private static void GenerateEngineFilesystem()
        {
            // List<string> RequiredDirs = new List<string> { "Temp", "Logs", "Config", "Crash" }; // Required directories.

            // DEBUG ONLY!!
            List<string> RequiredDirs = new List<string> { "Temp", "Logs", "Config" };

            if (!Directory.Exists(Path.Combine(Utils.CommonVars.ApplicationPath, "OctoEngine")))
            {
                Directory.CreateDirectory(Path.Combine(Utils.CommonVars.ApplicationPath, "OctoEngine"));
            }

            foreach (string dir in RequiredDirs) // Create required directories if they don't exist.
            {
                if (!Directory.Exists(Path.Combine(Utils.CommonVars.DataDir, dir)))
                {
                    Directory.CreateDirectory(Path.Combine(Utils.CommonVars.DataDir, dir));
                }
            }
        }

        private static void GenerateGameFilesystem(List<string> RequiredDirs)
        {
            if (!Directory.Exists(Path.Combine(Utils.CommonVars.ApplicationPath, "Data")))
            {
                Directory.CreateDirectory(Path.Combine(Utils.CommonVars.ApplicationPath, "Data"));
            }

            foreach (string dir in RequiredDirs) // Create required directories if they don't exist.
            {
                if (!Directory.Exists(Path.Combine(Utils.CommonVars.GameDataDir, dir)))
                {
                    Directory.CreateDirectory(Path.Combine(Utils.CommonVars.GameDataDir, dir));
                }
            }
        }

        private static void CreateEngineConfig(string appName)
        {
            if (!Xml.Exists(CommonVars.SettingsFilePath)) // If config doesn't exist, create it. (WARNING: Buggy)
            {
                XmlHelpers.SettingsFile().WriteData("AppName", appName);
                XmlHelpers.SettingsFile().WriteData("EngineVersion", "1" + appName);
                XmlHelpers.SettingsFile().WriteData("Settings/BranchTreatment", "1");
                Utils.Logging.LogWarn("Config was not found, so it was generated.");
            } 
            else
            {
                Utils.Logging.LogMessage("Config found!");
            }
        }

        public static void ReportCrash(string errorMsg)
        {
            // OCrash.CrashHandler.PassCrash(errorMsg);
        }

        public static class EULA
        {
            public static async Task<EULAObject> EULAGet()
            {
                string eulaVerPath = Path.Combine(CommonVars.ConfigDir, "legalversion.oc");
                if (!File.Exists(eulaVerPath))
                {
                    File.WriteAllText(eulaVerPath, "0");
                }

                return await Task.Run(async () =>
                {
                    WebClient client = new();
                    string latestAgreedVersion = File.ReadAllText(eulaVerPath);
                    EULAObject eulaResponse = await client.GetAsync<EULAObject>(StaticGameData.ApiUrl + "/eula?AgreedVersion=" + latestAgreedVersion + "&AppId=" + StaticGameData.AppId);
                    if (eulaResponse.Text != "NONEWEULA")
                    {
                        Logging.LogMessage("EULA: " + eulaResponse.Text);
                        TempStorage.WriteTempValue("eulatemp", eulaResponse.Version.ToString());
                    }
                    return eulaResponse;
                });
            }

            public static void EULAAgree()
            {
                string eulaVerPath = Path.Combine(CommonVars.ConfigDir, "legalversion.oc");
                File.WriteAllText(eulaVerPath, TempStorage.ReadTempValue("eulatemp"));
            }
        }
    }
}
