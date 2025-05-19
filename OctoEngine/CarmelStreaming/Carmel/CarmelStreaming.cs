using Miku;
using OctoEngine.Networking;

namespace OctoEngine.CarmelStreaming
{
    // Someone please fix this, my async knowledge is shitty
    public class CarmelStreamedAsset
    {
        public readonly string DefaultType = "bundle";
        public readonly string AccessToken = "none"; // Set up later with custom token.

        public string Filename { get; set; }

        public async Task<byte[]> FetchAssetAsync()
        {
            string url = String.Concat(
                StaticGameData.CarmelUrl,
                "?type=",
                DefaultType,
                "&filename=",
                Filename,
                "&access_token=",
                AccessToken
                );

            // Do network request stuff
            // Return asset as a byte
            WebClient client = new WebClient();
 
            return await client.GetAsync<byte[]>(url);
        }
    }
}
