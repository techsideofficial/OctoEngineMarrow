using Miku;

namespace OctoEngine.CarmelStreaming
{
    public class CarmelStreamedAsset
    {
        public readonly string DefaultType = "bundle";
        public readonly string AccessToken = "none"; // Set up later with custom token.

        public string Filename { get; set; }

        public byte[] FetchAsset()
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

            return System.Array.Empty<byte>();
        }
    }
}
