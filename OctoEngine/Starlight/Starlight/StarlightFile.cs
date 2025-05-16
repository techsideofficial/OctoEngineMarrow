using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starlight
{
    internal class StarlightFile // Starlight file.
    {
        static string Header = "STARLIGHT^o^\n";

        internal static void WriteFile(StarlightFormat strl, string filePath)
        {
            string fileContent = String.Concat(
                Header,
                StarlightSerializer.EncodeStarlight(strl)
                );

            File.WriteAllText(filePath, fileContent);
        }

        internal static StarlightFormat ReadFile(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            string rawStarlightData = fileText.Replace(Header, "");

            return StarlightSerializer.DecodeStarlight(rawStarlightData);
        }
    }
}
