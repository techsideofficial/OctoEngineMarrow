using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.Random;

namespace Starlight
{
    public class StarlightPackage
    {
        static string Header = "STARLIGHTPACKAGE^o^\n";
        static string FormatVersion = "v0.1dev\n";

        public static void WriteFile(StarlightFormat starlight)
        {
            string rawLogContent = File.ReadAllText(starlight.CrashLogPath);
            string formattedLogContent = System.String.Concat("<o>", rawLogContent, "<o>");
            string currentGuid = GUID.GenerateGUID();

            string fileContent = System.String.Concat( // Construct the format
                Header,
                FormatVersion,
                "\n",
                currentGuid,
                "<3starlight>",
                StarlightSerializer.EncodeStarlight(starlight),
                "<3starlight/>000\n\n",
                formattedLogContent,
                "starlight<3\n\nENDFILE=="
                // Get log content from log in Starlight path.
                );

            string starlightPath = Path.Combine( // puts file in temp path
                Path.GetTempPath(),
                "OctoEngine",
                starlight.AppName,
                "Starlight",
                currentGuid + ".starlightpackage"
                );

            Directory.CreateDirectory(Path.GetDirectoryName(starlightPath)); // Create dir if non-existant

            File.WriteAllText(starlightPath, fileContent);
        }

        public static StarlightViewerFormat ReadFile(string filePath)
        {
            string FileContent = File.ReadAllText(filePath);

            StarlightFormat starlight = StarlightSerializer.DecodeStarlight(FileContent.Split("<3starlight>")[1].Split("<3starlight/>000\n\n")[0]);
            string GUID = FileContent.Replace(Header + FormatVersion + "\n", "").Split("<3starlight>")[0];
            string LogContent = FileContent.Split("<3starlight/>000\n\n")[1].Replace("starlight<3\n\nENDFILE==", "");

            return new StarlightViewerFormat
            {
                starlight = starlight,
                GUID = GUID,
                LogContent = LogContent
            };
        }
    }
}
