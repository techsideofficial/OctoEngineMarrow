using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.Utils;

namespace OctoEngine.SaveData
{
    internal class SaveGame
    {
        internal static void WriteSaveValue(string name, string value)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "SaveGames", name.ToUpper() + ".AURORASAVE");

            if (File.Exists(TempPath))
            {
                DeleteSaveValue(name);
            }

            File.WriteAllText(TempPath, value);
        }

        internal static string ReadSaveValue(string name)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "SaveGames", name.ToUpper() + ".AURORASAVE");

            return File.ReadAllText(TempPath);
        }

        internal static string GetSaveValuePath(string name)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "SaveGames", name.ToUpper() + ".AURORASAVE");

            return TempPath;
        }

        internal static void DeleteSaveValue(string name)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "SaveGames", name.ToUpper() + ".AURORASAVE");

            File.Delete(TempPath);
        }
    }
}