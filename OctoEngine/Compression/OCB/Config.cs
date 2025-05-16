using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.Cryptography;

namespace OctoEngine.Compression.OCB
{
    public class Config
    {
        // This is insecure. Store it another way.
        // Original: gok8YwavgKfY/B9YRuAzROHZH+LUmR+FL19ZwypVlQY=
        public static string EncryptionKey = Obfuscation.Caesar(@"jrn;\\zdyjNi\\2E<\\UxD}URK]K.OXpU.IO4<]z|sYoT\\@", -3);
        // Original: w/MRAc+WtdT7JOoTgfK1FA==
        public static string InitVector = Obfuscation.Caesar(@"z2PUDf.ZwgW:MRrWjiN4ID@@", -3);
    }
}
