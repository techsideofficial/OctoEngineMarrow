using System;
using System.IO;

namespace OctoEngine
{
    public class TempStorage
    {
        public static void WriteTempValue(string name, string value)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "Temp", name + ".otmp");

            try
            {
                File.WriteAllText(TempPath, value);
            }
            catch (Exception ex)
            {
                // Utils.Logging.LogError($"Error writing temp value: {ex.Message}");
            }
        }

        public static string ReadTempValue(string name)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "Temp", name + ".otmp");

            if (!File.Exists(TempPath))
            {
                return "0";
            }

            try
            {
                return File.ReadAllText(TempPath);
            }
            catch (Exception ex)
            {
                // Utils.Logging.LogError($"Error reading temp value: {ex.Message}");
                return "0";
            }
        }

        public static string[]? ReadTempLines(string name)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "Temp", name + ".otmp");

            if (!File.Exists(TempPath))
            {
                return null;
            }

            try
            {
                return File.ReadAllLines(TempPath);
            }
            catch (Exception ex)
            {
                // Utils.Logging.LogError($"Error reading temp value: {ex.Message}");
                return null;
            }
        }

        public static void DeleteTempValue(string name)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "Temp", name + ".otmp");

            if (File.Exists(TempPath))
            {
                try
                {
                    File.Delete(TempPath);
                }
                catch (Exception ex)
                {
                    // Utils.Logging.LogError($"Error deleting temp value: {ex.Message}");
                }
            }
        }

        public static string GetTempPath(string name)
        {
            string TempPath = Path.Combine(Utils.CommonVars.DataDir, "Temp", name + ".otmp");

            if (!File.Exists(TempPath))
            {
                return "0";
            }

            try
            {
                return TempPath;
            }
            catch (Exception ex)
            {
                // Utils.Logging.LogError($"Error reading temp value: {ex.Message}");
                return "0";
            }
        }
    }
}
