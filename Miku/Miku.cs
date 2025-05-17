using System;
using System.IO;

namespace Miku
{
    public class StaticGameData
    {
        public static readonly string AppId = "arparec-toy-story-3-the-video-game";
        public static readonly string AppName = "Toy Story 3: The Video Game";
        public static readonly string AppVersion = "game_dev";
        public static readonly string AppDeveloper = "ArpaRec";
        public static readonly string ApiUrl = "https://prod-freya.arparec.xyz/api";
        public static readonly string StarlightUrl = "https://prod-freya.arparec.xyz/api/starlight";
        public static readonly string CarmelUrl = "https://carmelcdn.arparec.xyz/streamed";
        public static readonly string CustomBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow", "Stress Level Zero", "BONELAB", "Mods", "ArpaRec.TS3Game", "Octo", AppId);
        // BONELAB PATH: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow", "Stress Level Zero", "BONELAB");
    }
}