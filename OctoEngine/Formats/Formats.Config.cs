using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace OctoEngine.Formats
{
    public class ConfigSetting<T>
    {
        [JsonProperty("_id")]
        public ObjectId Id { get; set; }

        [JsonProperty("configObject")]
        public T ConfigObject { get; set; }

        [JsonProperty("configId")]
        public string ConfigId { get; set; }
    }
}
