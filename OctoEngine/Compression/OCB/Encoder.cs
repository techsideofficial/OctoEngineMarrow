using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace OctoEngine.Compression.OCB
{
    public class FolderEncoder
    {
        private Dictionary<string, long> fileIndex = new();

        public void Encode(string sourceFolderPath, string outputFile, bool debugLog, bool useEncryption = false)
        {
            using (var writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
            {
                TraverseDirectory(sourceFolderPath, writer, sourceFolderPath, debugLog, useEncryption);
            }
        }

        private void TraverseDirectory(string folderPath, BinaryWriter writer, string rootPath, bool debugLog, bool useEncryption)
        {
            foreach (var file in Directory.GetFiles(folderPath))
            {
                WriteFileToStream(file, writer, rootPath, debugLog, useEncryption);
            }

            foreach (var directory in Directory.GetDirectories(folderPath))
            {
                writer.Write("DIR"); // Folder header identifier
                var relativeDirPath = GetRelativePath(directory, rootPath);
                writer.Write(relativeDirPath);

                TraverseDirectory(directory, writer, rootPath, debugLog, useEncryption);

                writer.Write("END_DIR");
            }
        }

        private void WriteFileToStream(string filePath, BinaryWriter writer, string rootPath, bool debugLog, bool useEncryption)
        {
            writer.Write("FILE"); // File header identifier
            var relativeFilePath = GetRelativePath(filePath, rootPath);
            writer.Write(relativeFilePath);

            var fileBytes = File.ReadAllBytes(filePath);

            if (useEncryption)
            {
                fileBytes = EncryptionInterface.Encrypt(fileBytes);
            }

            writer.Write(fileBytes.Length);
            writer.Write(fileBytes);

            if (debugLog)
            {
                Console.WriteLine("Written: " + relativeFilePath);
            }
        }

        private string GetRelativePath(string fullPath, string rootPath)
        {
            return fullPath.Substring(rootPath.Length).TrimStart(Path.DirectorySeparatorChar);
        }

        public void BuildFileIndex(string encodedFilePath)
        {
            fileIndex.Clear();

            using (var reader = new BinaryReader(File.Open(encodedFilePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    var header = reader.ReadString();

                    if (header == "FILE")
                    {
                        var relativeFilePath = reader.ReadString();
                        var filePosition = reader.BaseStream.Position;

                        var fileSize = reader.ReadInt32();
                        reader.BaseStream.Seek(fileSize, SeekOrigin.Current);

                        fileIndex[relativeFilePath] = filePosition;
                    }
                    else if (header == "DIR" || header == "END_DIR")
                    {
                        reader.ReadString(); // Skip directory metadata
                    }
                }
            }
        }

        public byte[] LoadFile(string encodedFilePath, string relativeFilePath, bool useDecryption = false)
        {
            if (!fileIndex.ContainsKey(relativeFilePath))
            {
                throw new FileNotFoundException($"File '{relativeFilePath}' not found in the encoded archive.");
            }

            using (var reader = new BinaryReader(File.Open(encodedFilePath, FileMode.Open)))
            {
                reader.BaseStream.Seek(fileIndex[relativeFilePath], SeekOrigin.Begin);

                var fileSize = reader.ReadInt32();
                var fileBytes = reader.ReadBytes(fileSize);

                if (useDecryption)
                {
                    fileBytes = EncryptionInterface.Decrypt(fileBytes);
                }

                return fileBytes;
            }
        }
    }
}
