using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.Cryptography;
using OctoEngine.Utils;

namespace OctoEngine.Networking
{
    internal class Cache
    {
        static string CacheDir = Path.Combine(CommonVars.DataDir, "NetCache");
        static byte[] header = Encoding.UTF8.GetBytes("OCTO&&NETCACHE");
        static byte[] expiry = BitConverter.GetBytes(DateTime.UtcNow.AddDays(7).Ticks);
        internal static void WriteCache(string url, byte[] data)
        {
            string hashedUrl = Hashing.HashWithSHA256(url);

            byte[] cacheData = new byte[header.Length + expiry.Length + data.Length];
            Buffer.BlockCopy(header, 0, cacheData, 0, header.Length);
            Buffer.BlockCopy(expiry, 0, cacheData, header.Length, expiry.Length);
            Buffer.BlockCopy(data, 0, cacheData, header.Length + expiry.Length, data.Length);

            File.WriteAllBytes(Path.Combine(CacheDir, hashedUrl), cacheData);
        }

        internal static byte[] ReadCache(string url)
        {
            string hashedUrl = Hashing.HashWithSHA256(url);
            byte[] data = File.ReadAllBytes(Path.Combine(CacheDir, hashedUrl));

            BinaryReader reader = new BinaryReader(new MemoryStream(data));

            reader.ReadBytes(header.Length);
            reader.ReadBytes(expiry.Length);
            return reader.ReadBytes(data.Length);
        }

        internal static bool CheckCache(string url)
        {
            return File.Exists(Path.Combine(CacheDir, Hashing.HashWithSHA256(url)));
        }
    }
}
