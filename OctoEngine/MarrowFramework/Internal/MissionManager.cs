using Newtonsoft.Json;

namespace OctoEngine.MarrowFramework.Internal
{
    internal class MissionManager
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
            if (MissionManager.GetMission(MissionId).Available)
            {
                int? _tempMissionState = Int32.Parse(SaveGame.ReadData("Missions/" + MissionId + "/State"));
                if (_tempMissionState != 1 && _tempMissionState != 2 && _tempMissionState != 3)
                {
                    SaveGame.WriteValue("Missions/" + MissionId + "/State", "1");
                    NotificationHelper.InfoNotification(MissionManager.GetMission(MissionId).Name, MissionManager.GetMission(MissionId).Description, 5);
                    ModLog.LogMessage(String.Concat("Successfully set missionstate of ", MissionId, " to InProgress"));
                }
                else
                {
                    ModLog.LogWarn(String.Concat("Cannot give mission ", MissionId, "."));
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
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("coins_awarded")]
        public int CoinsAwarded { get; set; }

        [Newtonsoft.Json.JsonProperty("available")]
        public bool Available { get; set; }
    }
}