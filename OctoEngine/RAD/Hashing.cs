using System;

namespace OctoEngine.RAD
{
    class HashingInternal
    {
        public static ulong HashBytes(byte[] b, ulong[] t)
        {
            ulong h = 0xFFFFFFFFFFFFFFFF;
            foreach (byte v in b)
            {
                h = (ulong)v ^ t[(h >> 56)] ^ (h << 8);
            }
            return h;
        }

        public ulong HashString(string s, ulong[] t)
        {
            s = s.ToLower();
            return HashBytes(System.Text.Encoding.UTF8.GetBytes(s), t);
        }

        public static ulong[] GenerateHashLookupArray()
        {
            ulong[] seed = new ulong[256];
            ulong i = 0;
            ulong s = 0x95AC9329AC4BC9B5;

            while (i < 256)
            {
                ulong num1 = 0;

                if ((i & 0x80) != 0)
                {
                    num1 = 0x2B5926535897936A;
                }

                if ((i & 0x40) != 0)
                {
                    num1 = 0xBEF5B57AF4DC5ADF;
                    if ((i & 0x80) == 0)
                    {
                        num1 = s;
                    }
                }

                ulong num2 = (num1 * 2) ^ s;
                if ((i & 0x20) == 0)
                {
                    num2 = num1 * 2;
                }

                num1 = (num2 * 2) ^ s;
                if ((i & 0x10) == 0)
                {
                    num1 = num2 * 2;
                }

                num2 = (num1 * 2) ^ s;
                if ((i & 8) == 0)
                {
                    num2 = num1 * 2;
                }

                num1 = (num2 * 2) ^ s;
                if ((i & 4) == 0)
                {
                    num1 = num2 * 2;
                }

                num2 = (num1 * 2) ^ s;
                if ((i & 2) == 0)
                {
                    num2 = num1 * 2;
                }

                num1 = (num2 * 2) ^ s;
                if ((i & 1) == 0)
                {
                    num1 = num2 * 2;
                }

                seed[i] = num1 * 2;
                i++;
            }

            return seed;
        }


        public ulong[] hashLookupArray = GenerateHashLookupArray();
    }

    public class Hashing
    {
        public static ulong ToSymbol(string input)
        {
            HashingInternal h = new();
            Console.WriteLine(h.hashLookupArray.ToString());
            return h.HashString(input, h.hashLookupArray);
        }
    }
}