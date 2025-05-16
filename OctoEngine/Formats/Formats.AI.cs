using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace OctoEngine.Formats
{
    public class ModuleAuraAIConfig
    {
        [JsonProperty("history")]
        public List<AIChatEntry> History { get; set; }
    }

    public class AIChatEntry
    {
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("parts")]
        public List<AIPart> Parts { get; set; }
    }

    public class AIPart
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}