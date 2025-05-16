using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.Cryptography;

namespace OctoEngine.Compression.OCB
{
    internal class EncryptionInterface
    {
        internal static byte[] Encrypt(byte[] data)
        {
            return Encryption.EncryptDataWithAes(data, Config.EncryptionKey, Config.InitVector);
        }

        internal static byte[] Decrypt(byte[] data)
        {
            return Encryption.DecryptDataWithAes(data, Config.EncryptionKey, Config.InitVector);
        }
    }
}
