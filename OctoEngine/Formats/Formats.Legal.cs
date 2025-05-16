using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace OctoEngine.Formats
{
    public class EULAObject
    {
        public int Version { get; set; }
        public string Text { get; set; }
    }

    public class LegalDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] // Store as a string in MongoDB
        public Guid UUID = Guid.NewGuid();
        public string AppId { get; set; }
        public List<EULAObject> EULA { get; set; }
    }

    public class AccountLegal
    {
        public int EulaVersion { get; set; }
        public bool HasAcceptedAuraAITS { get; set; }
    }
}
