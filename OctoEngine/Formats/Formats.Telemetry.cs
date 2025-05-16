using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class VTelemetryObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id = Guid.NewGuid();
        public string AppId { get; set; }
        public Dictionary<string, int> Metrics { get; set; }
    }
}
