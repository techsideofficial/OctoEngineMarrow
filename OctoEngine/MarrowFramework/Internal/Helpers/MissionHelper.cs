using Newtonsoft.Json;

namespace OctoEngine.MarrowFramework.Internal.Helpers
{
    internal class MissionHelper
    {
        internal static List<Mission> LoadMissionData()
        {
            string jsonData = File.ReadAllText(Path.Combine(Utils.CommonVars.GameDataDir, "Config", "data_missions.json"));

            return JsonConvert.DeserializeObject<List<Mission>>(jsonData);
        }

        internal static Mission GetMission(string MissionId)
        {
            List<Mission> missionList = LoadMissionData();
            Mission mission = missionList.FirstOrDefault(m => m.Id == MissionId) ?? null;

            if (mission != null)
            {
                ModLog.LogMessage($"Retrieved mission: {mission.Name}");
                return mission;
            }
            else
            {
                ModLog.LogError(string.Concat($"Mission {MissionId} is not a valid missionId"));
                return null;
            }
        }

        internal static void GiveMission(string MissionId)
        {
            if (GetMission(MissionId).Available)
            {
                int? _tempMissionState = int.Parse(SaveGameHelper.ReadData("Missions/" + MissionId + "/State"));
                if (_tempMissionState != 1 && _tempMissionState != 2 && _tempMissionState != 3)
                {
                    SaveGameHelper.WriteValue("Missions/" + MissionId + "/State", "1");
                    NotificationHelper.InfoNotification(GetMission(MissionId).Name, GetMission(MissionId).Description, 5);
                    ModLog.LogMessage(string.Concat("Successfully set missionstate of ", MissionId, " to InProgress"));
                }
                else
                {
                    ModLog.LogWarn(string.Concat("Cannot give mission ", MissionId, "."));
                }
            }
            else
            {
                ModLog.LogWarn("Mission not available.");
            }
        }
    }

    internal class Mission
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("coins_awarded")]
        public int CoinsAwarded { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }
    }
}