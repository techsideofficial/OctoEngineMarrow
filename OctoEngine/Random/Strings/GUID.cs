using System.Text;

namespace OctoEngine.Random
{
    public class GUID
    {
        public static string GenerateGUID()
        {
            System.Random rnd = new System.Random();
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] numbers = "0123456789".ToCharArray();
            char[][] charLists = { letters, numbers };

            List<string> guidParts = new List<string>();
            StringBuilder currentPart = new(5); // Add reused StringBuilder

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    char[] rndCharSet = charLists[rnd.Next(charLists.Length)];
                    currentPart.Append(rndCharSet[rnd.Next(rndCharSet.Length)]);
                }
                guidParts.Add(currentPart.ToString());
            }

            return string.Join('-', guidParts);
        }

        public static string GenerateCustomGUID(int partCount, int partSize)
        {
            System.Random rnd = new System.Random();
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] numbers = "0123456789".ToCharArray();
            char[][] charLists = { letters, numbers };

            List<string> guidParts = new List<string>();
            StringBuilder currentPart = new(5); // Add reused StringBuilder

            for (int i = 0; i < partCount; i++)
            {
                for (int j = 0; j < partSize; j++)
                {
                    char[] rndCharSet = charLists[rnd.Next(charLists.Length)];
                    currentPart.Append(rndCharSet[rnd.Next(rndCharSet.Length)]);
                }
                guidParts.Add(currentPart.ToString());
            }

            return string.Join('-', guidParts);
        }
    }
}
