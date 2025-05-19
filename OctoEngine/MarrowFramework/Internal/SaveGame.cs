namespace OctoEngine.MarrowFramework.Internal
{
    // yes, i know, i'm using XML here
    public class SaveGame
    {
        public static Xml saveDat = new Xml(Path.Combine(Utils.CommonVars.GameDataDir, "SaveData", "DeveloperSave.xml"));
        public static void WriteValue(string key, string value)
        {
            saveDat.WriteData("SaveGame/" + key, value);
        }

        public static string ReadData(string key)
        {
            if (saveDat.ReadData("SaveGame/" + key) != null)
            {
                return saveDat.ReadData("SaveGame/" + key);
            }
            saveDat.WriteData("SaveGame/" + key, "0");
            return "0";
        }
    }
}