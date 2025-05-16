using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class PluginManifest
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public float Version { get; set; }
        public string Description { get; set; }
        public string[] Dependencies { get; set; }
    }
}
