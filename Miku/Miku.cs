using System;
using System.IO;
using OctoEngine;

namespace Miku
{
    public class StaticGameData
    {
        public static readonly Xml XmlFile = new Xml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "octo_config.xml"));
        public static readonly string AppId = XmlFile.ReadData("Miku/AppId");
        public static readonly string AppName = XmlFile.ReadData("Miku/AppName");
        public static readonly string AppVersion = XmlFile.ReadData("Miku/AppVersion");
        public static readonly string AppDeveloper = XmlFile.ReadData("Miku/AppDeveloper");
        public static readonly string ApiUrl = XmlFile.ReadData("Miku/Network/Api");
        public static readonly string StarlightUrl = XmlFile.ReadData("Miku/Network/Starlight");
        public static readonly string CarmelUrl = XmlFile.ReadData("Miku/Network/Carmel");
        public static readonly string CustomBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Octo", AppId);
        // public static readonly string CustomBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow", "Stress Level Zero", "BONELAB", "Octo", AppId);
        // BONELAB PATH: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow", "Stress Level Zero", "BONELAB");
    }
}