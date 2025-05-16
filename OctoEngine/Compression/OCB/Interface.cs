using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.RAD;

namespace OctoEngine.Compression.OCB
{
    internal class InternalContent
    {
        internal static string tempPath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\OctoEngine\OCB\";

        internal static void Load(string contentFile, string contentName)
        {
            string safeContentPath = GetSafePath(contentName);
            if (safeContentPath != null)
            {
                FolderDecoder folderDecoder = new FolderDecoder();
                folderDecoder.Decode(contentFile, safeContentPath, false, false);
            }
            else
            {
                Console.WriteLine("Invalid content name: Potential directory traversal detected.");
            }
        }

        internal static void LoadEncrypted(string contentFile, string contentName)
        {
            string safeContentPath = GetSafePath(contentName);
            if (safeContentPath != null)
            {
                FolderDecoder folderDecoder = new FolderDecoder();
                folderDecoder.Decode(contentFile, safeContentPath, false, true);
            }
            else
            {
                Console.WriteLine("Invalid content name: Potential directory traversal detected.");
            }
        }

        internal static void Unload(string contentName)
        {
            string safeContentPath = GetSafePath(contentName);
            if (safeContentPath != null && Directory.Exists(safeContentPath))
            {
                Directory.Delete(safeContentPath, true);
            }
            else
            {
                Console.WriteLine("Invalid content name or directory doesn't exist.");
            }
        }

        internal static string GetFile(string contentName, string filePath)
        {
            return tempPath + Hashing.ToSymbol(contentName).ToString() + @"\" + filePath;
        }

        /// <summary>
        /// Loads an individual file from the encoded archive.
        /// </summary>
        internal static byte[] LoadIndividualFile(string contentFile, string contentName, string relativeFilePath, bool useDecryption = false)
        {
            string safeContentPath = GetSafePath(contentName);
            if (safeContentPath != null)
            {
                FolderDecoder folderDecoder = new FolderDecoder();
                folderDecoder.BuildFileIndex(contentFile); // Ensure the file index is built

                try
                {
                    return folderDecoder.LoadFile(contentFile, relativeFilePath, useDecryption);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return Array.Empty<byte>();
                }
            }
            else
            {
                Console.WriteLine("Invalid content name: Potential directory traversal detected.");
                return Array.Empty<byte>();
            }
        }

        private static string GetSafePath(string contentName)
        {
            try
            {
                string combinedPath = Path.Combine(tempPath, Hashing.ToSymbol(contentName).ToString());
                string fullPath = Path.GetFullPath(combinedPath);

                if (fullPath.StartsWith(Path.GetFullPath(tempPath), StringComparison.OrdinalIgnoreCase))
                {
                    return fullPath;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
