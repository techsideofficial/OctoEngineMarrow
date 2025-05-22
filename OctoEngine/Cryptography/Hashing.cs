using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Cryptography
{
    internal class Hashing
    {
        public static string HashWithSHA256(string value)
        {
            var byteArray = SHA256.HashData(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(byteArray);
        }
    }
}
