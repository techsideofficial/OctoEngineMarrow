using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.SaveData
{
    public class SaveStructure
    {

    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class ProgressionData
    {
        [JsonProperty]
        public int FormatVersion { get; set; }
        [JsonProperty]
        public int SaveSlot { get; set; }
        [JsonProperty]
        public string SUserName { get; set; }
        [JsonProperty]
        public string OUsername { get; set; }
        [JsonProperty]
        public MissionStateObject[] Missions { get; set; }
        [JsonProperty]
        public int TotalCoins { get; set; }
        [JsonProperty]
        public int GoldStars { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class AreaUnlocks
    {
        [JsonProperty]
        public int FormatVersion { get; set; }
        [JsonProperty]
        public int SaveSlot { get; set; }
        [JsonProperty]
        public bool GlenUnlocked { get; set; }
        [JsonProperty]
        public bool SpaceportUnlocked { get; set; }
        [JsonProperty]
        public bool HauntedUnlocked { get; set; }
        [JsonProperty]
        public bool MountainUnlocked { get; set; }
        [JsonProperty]
        public bool SuburbUnlocked { get; set; }
        [JsonProperty]
        public bool BenditoUnlocked { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class MissionStateObject
    {
        [JsonProperty]
        public string MissionId { get; set; }
        [JsonProperty]
        public int MissionState { get; set; }
    }
}
