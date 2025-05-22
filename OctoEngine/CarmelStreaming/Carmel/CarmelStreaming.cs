using Miku;
using OctoEngine.Formats;
using OctoEngine.MarrowFramework.Internal;
using OctoEngine.Networking;

namespace OctoEngine.CarmelStreaming
{
    // Someone please fix this, my async knowledge is shitty
    public class CarmelStreamedAsset
    {
        public readonly string DefaultType = "bundle";
        public readonly string AccessToken = "none"; // Set up later with custom token.

        public string Filename { get; set; }

        public static byte[] GetAsset(string Type, string AccessToken, string Filename)
        {
            string url = String.Concat(
                StaticGameData.CarmelUrl,
                "?type=",
                Type,
                "&filename=",
                Filename,
                "&access_token=",
                AccessToken
                );

            byte[] tempResponse = Array.Empty<byte>();
            // Do network request stuff
            // Return asset as a byte
            if (Cache.CheckCache(url))
            {
                return Cache.ReadCache(url);
            } 
            else
            {
                var client = new NetClient();

                ModLog.LogMessage("Fetched ");
                client.GetBytes(url,
                    onSuccess: response => tempResponse = response,
                    onError: ex => Net.INetError(ex.Message)
                );

                return HandleCarmelResponse(url, tempResponse);
            }
        }

        private static byte[] HandleCarmelResponse(string url, byte[] response)
        {
            Cache.WriteCache(url, response);
            return response;
        }
    }
}
