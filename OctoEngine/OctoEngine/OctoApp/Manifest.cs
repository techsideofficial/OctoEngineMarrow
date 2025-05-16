using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine
{
    public class WebAppManifest
    {
        [JsonProperty("appName")]
        public string AppName = Miku.StaticGameData.AppName;
        [JsonProperty("appVersion")]
        public string AppVersion = Miku.StaticGameData.AppVersion;
        [JsonProperty("appDev")]
        public string AppDeveloper = Miku.StaticGameData.AppDeveloper;
        [JsonProperty("starlightApi")]
        public string StarlightAPI = Miku.StaticGameData.StarlightUrl;
    }
}
