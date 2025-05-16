namespace OctoEngine.MarrowFramework
{
    internal class ContentLoader
    {
        public static Dictionary<string, Compression.OCB.Content> contentFilesDict;
        public static void LoadContent()
        {
            contentFilesDict = new();
            Directory.GetFiles(Path.Combine(Utils.CommonVars.GameDataDir, "Bundles")).ToList().ForEach(x =>
            {
                if (x.EndsWith(".ocb") || x.EndsWith(".eocb"))
                {
                    contentFilesDict.Add(Path.GetFileName(x).Split(".")[0], new(Path.GetFileName(x).Split(".")[0], Path.GetFullPath(x)));
                }
            });

            foreach (var content in contentFilesDict)
            {
                if (Path.GetFileName(content.Value.packagePath).Split(".")[1] == "ocb")
                {
                    content.Value.Load();
                }
            }
        }

        public static void UnloadContent()
        {
            foreach (var content in contentFilesDict)
            {
                content.Value.Unload();
                contentFilesDict.Remove(content.Key);
            }
        }

        public static byte[] GetContentFile(string packname, string file)
        {
            if (contentFilesDict.ContainsKey(packname))
            {
                if (Path.GetFileName(contentFilesDict[packname].packagePath).Split(".")[1] == "eocb")
                {
                    return contentFilesDict[packname].GetSingleFileEncryptedBundle(file);
                }
                return File.ReadAllBytes(contentFilesDict[packname].GetFile(file));
            }
            else
            {
                throw new Exception($"Content file {packname} not found.");
            }
        }
    }
}

// TODO: Load UI icons from .eocb file.