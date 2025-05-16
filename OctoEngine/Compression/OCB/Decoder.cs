using System;
using System.Collections.Generic;
using System.IO;

namespace OctoEngine.Compression.OCB
{
    public class FolderDecoder
    {
        private Dictionary<string, long> fileIndex = new();

        /// <summary>
        /// Builds the file index for quick access to individual files.
        /// </summary>
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

        /// <summary>
        /// Loads and optionally decrypts a specific file from the encoded archive.
        /// </summary>
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

        /// <summary>
        /// Decodes the entire folder from the encoded archive.
        /// </summary>
        public void Decode(string encodedFilePath, string outputFolderPath, bool useDecryption = false, bool debugLog = false)
        {
            Directory.CreateDirectory(outputFolderPath);

            using (var reader = new BinaryReader(File.Open(encodedFilePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    var header = reader.ReadString();

                    if (header == "FILE")
                    {
                        var relativeFilePath = reader.ReadString();
                        var fileSize = reader.ReadInt32();
                        var fileBytes = reader.ReadBytes(fileSize);

                        if (useDecryption)
                        {
                            fileBytes = EncryptionInterface.Decrypt(fileBytes);
                        }

                        var outputFilePath = Path.Combine(outputFolderPath, relativeFilePath);
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath)!);
                        File.WriteAllBytes(outputFilePath, fileBytes);

                        if (debugLog)
                        {
                            Console.WriteLine("Decoded: " + relativeFilePath);
                        }
                    }
                    else if (header == "DIR")
                    {
                        var relativeDirPath = reader.ReadString();
                        var outputDirPath = Path.Combine(outputFolderPath, relativeDirPath);
                        Directory.CreateDirectory(outputDirPath);

                        if (debugLog)
                        {
                            Console.WriteLine("Created Directory: " + relativeDirPath);
                        }
                    }
                    else if (header == "END_DIR")
                    {
                        // End of directory marker, no action needed
                    }
                }
            }
        }
    }
}
