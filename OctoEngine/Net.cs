using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OctoEngine.Formats;
using OctoEngine.MarrowFramework.Internal;
using OctoEngine.Networking;

namespace OctoEngine
{
    internal class Net
    {
        internal static void INetError(string err)
        {
            NS bNS = new NS
            {
                APIUrl = "",
                BugReporterUrl = "",
                CarmelUrl = "",
                AuroraUrl = "",
                StAPIUrl = "",
                MaeNetUrl = ""
            };

            ModLog.LogError("Network error: Unable to connect to the server: " + err);
            TempStorage.WriteTempValue("ns", JsonConvert.SerializeObject(bNS));
        }

        internal static void CacheNS(string nsUrl)
        {
            var client = new NetClient();

            ModLog.LogMessage("Fetching NS data...");
            client.Get(nsUrl,
                onSuccess: response => TempStorage.WriteTempValue("ns", response),
                onError: ex => INetError(ex.Message)
            );
        }

        internal static NS GetUrl()
        {
            return JsonConvert.DeserializeObject<NS>(TempStorage.ReadTempValue("ns"));
        }
    }
}
