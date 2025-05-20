using MelonLoader;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using BoneLib;
using System.Collections;
using OctoEngine.MarrowFramework.Console;
using OctoEngine.MarrowFramework;
using OctoEngine.Audio;
using OctoEngine.Utils;

namespace OctoEngine
{
    public class DLLMain : MelonPlugin
    {
        public static Xml DebugConfig;
        public override void OnInitializeMelon()
        {
            Injector.InjectBehaviors();
            OCppConstants.logger = new MelonLogger.Instance("OctoEngine", System.Drawing.Color.Cyan);
            List<string> RequiredDirs = new List<string> { "Config", "Content", "SaveData" };
            // TODO: Add the ability to disable console logging to prevent double logs.
            OctoApp.RegisterApplication(false, RequiredDirs, false);
            ModLog.LogMessage("Registered application in domain.");
            ModLog.LogMessage("Successfully initialized!");
            ModLog.LogMessage("Mod is ready!");
            DebugConfig = new Xml(Path.Combine(Utils.CommonVars.DataDir, "Config", "SETTINGS", "OCDEBUGSETTINGS.XML"));

            AsyncBootstrap();
        }

        public async void AsyncBootstrap()
        {
            if (DebugConfig.ReadData("DebugSettings/EnableConsole") == "1")
            {
                await OMConsoleServer.StartServer("ws://localhost:8564/");
            }

            if (DebugConfig.ReadData("DebugSettings/EnableFMOD") == "1")
            {
                HarmonyPatchHelper.ApplyPatches(MelonAssembly.Assembly);
                OCppConstants.fmodsys = new FMODAudioSystem();
                OCppConstants.fmodsys.LoadBanks(CommonVars.DataDir);
            }
        }

        public override void OnApplicationQuit()
        {
            ModLog.LogMessage("Quitting game...");
        }
    }
}