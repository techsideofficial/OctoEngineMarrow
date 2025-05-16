using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Compression.OCB
{
    public class Content
    {
        public string packageName;
        public string packagePath;

        public Content(string pkName, string pkPath)
        {
            packageName = pkName;
            packagePath = pkPath;
        }

        public void Load()
        {
            InternalContent.Load(packagePath, packageName);
        }

        public void LoadEncrypted()
        {
            InternalContent.LoadEncrypted(packagePath, packageName);
        }



        public void Unload()
        {
            InternalContent.Unload(packageName);
        }

        public string GetFile(string filePath)
        {
            return InternalContent.GetFile(packageName, filePath);
        }

        public byte[] GetSingleFileEncryptedBundle(string filePath)
        {
            return InternalContent.LoadIndividualFile(packagePath, packageName, filePath, true);
        }
    }

}
