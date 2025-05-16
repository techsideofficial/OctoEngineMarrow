using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Random
{
    public static class String
    {
        public static string GenerateString(int length)
        {
            System.Random rnd = new System.Random();
            char[] lettersLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] numbers = "0123456789".ToCharArray();
            char[][] charLists = { lettersLower, lettersUpper, numbers };
            string randStringBuild = "";
            for (int i = 0; i < length; i++)
            {
                char[] rndCharSet = charLists[rnd.Next(charLists.Length)];
                randStringBuild += rndCharSet[rnd.Next(rndCharSet.Length)];
            }
            return randStringBuild;
        }
    }
}
