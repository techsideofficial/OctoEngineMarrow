namespace AuroraFramework.TempStorage
{
    public class TempManager
    {
        public static void WriteTempValue(string name, string value)
        {
#if DEBUG 
            string tempName = name;
#else
            string tempName = OctoEngine.RAD.Hashing.ToSymbol(name).ToString();
#endif
            OctoEngine.TempStorage.WriteTempValue(tempName, value);
        }

        public static string ReadTempValue(string name)
        {
#if DEBUG
            string tempName = name;
#else
            string tempName = OctoEngine.RAD.Hashing.ToSymbol(name).ToString();
#endif
            return OctoEngine.TempStorage.ReadTempValue(tempName);
        }

        public static string[] ReadTempLines(string name)
        {
#if DEBUG
            string tempName = name;
#else
            string tempName = OctoEngine.RAD.Hashing.ToSymbol(name).ToString();
#endif
            return OctoEngine.TempStorage.ReadTempLines(tempName);
        }

        public static void DeleteTempValue(string name)
        {
#if DEBUG
            string tempName = name;
#else
            string tempName = OctoEngine.RAD.Hashing.ToSymbol(name).ToString();
#endif
            OctoEngine.TempStorage.DeleteTempValue(tempName);
        }
    }
}
