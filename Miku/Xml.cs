using System;
using System.Xml;

namespace OctoEngine
{
    public class Xml
    {
        private string filePath;

        public static bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public Xml(string filePath)
        {
            this.filePath = filePath;

            // Ensure the file exists with a root node
            if (!System.IO.File.Exists(filePath))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = null;
                XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(declaration);
                XmlElement root = xmlDocument.CreateElement("OctoApp");
                xmlDocument.AppendChild(root);
                xmlDocument.Save(filePath);
            }
        }

        public void WriteData(string path, string value)
        {
            XmlDocument xmlDocument = new();
            xmlDocument.Load(filePath);

            string[] nodes = path.Split('/');
            XmlNode currentNode = xmlDocument.DocumentElement;

            foreach (string nodeName in nodes)
            {
                XmlNode childNode = currentNode.SelectSingleNode(nodeName);
                if (childNode == null)
                {
                    childNode = xmlDocument.CreateElement(nodeName);
                    currentNode.AppendChild(childNode);
                }
                currentNode = childNode;
            }

            currentNode.InnerText = value;
            xmlDocument.Save(filePath);
        }

        public string ReadData(string path)
        {
            XmlDocument xmlDocument = new();
            xmlDocument.Load(filePath);

            XmlNode node = xmlDocument.DocumentElement.SelectSingleNode(path);
            return node?.InnerText ?? null;
        }
    }
}
