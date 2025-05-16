namespace OctoEngine.CarmelStreaming
{
    public class CarmelStreamedAsset
    {
        // https://carmelcdn.arparec.xyz/streamed?type=audio&filename=loud-ass-pc.wav&access_token=none
        public readonly string CarmelBaseUrl = "https://carmelcdn.arparec.xyz/streamed";
        public readonly string DefaultType = "bundle";
        public readonly string AccessToken = "none"; // Set up later with custom token.

        public string Filename { get; set; }

        public byte[] FetchAsset()
        {
            string url = String.Concat(
                CarmelBaseUrl,
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
