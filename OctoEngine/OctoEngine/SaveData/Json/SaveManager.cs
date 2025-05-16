using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OctoEngine.SaveData
{
    public class SaveManager
    {
        internal static void CreateNewBaseProgression()
        {
            string PDPath = Path.Combine(Utils.CommonVars.DataDir, "SaveData", "BaseProgression.json");
            ProgressionData baseProgression = new();

            MissionStateObject mis = new()
{
    MissionId = "mission_default",
    MissionState = 3
};

            baseProgression.FormatVersion = 4;
            baseProgression.SaveSlot = 0;
            baseProgression.SUserName = "DefaultUser";
            baseProgression.OUsername = "DefaultUser";
            baseProgression.Missions = new MissionStateObject[] { mis };
            baseProgression.TotalCoins = 0;
            baseProgression.GoldStars = 0;

            File.WriteAllText(PDPath, JsonConvert.SerializeObject(baseProgression, Newtonsoft.Json.Formatting.Indented));
        }

        public static bool SaveExists()
        {
            if (File.Exists(Path.Combine(Utils.CommonVars.DataDir, "SaveData", "BaseProgression.json")))
            {
                return true;
            }
            return false;
        }

        internal static void CreateNewAreaUnlocks()
        {
            string UDPath = Path.Combine(Utils.CommonVars.DataDir, "SaveData", "AreaUnlocks.json");

            AreaUnlocks areaUnlocks = new()
{
    FormatVersion = 1,
    SaveSlot = 0,
    GlenUnlocked = false,
    SpaceportUnlocked = false,
    HauntedUnlocked = false,
    MountainUnlocked = false,
    SuburbUnlocked = false,
    BenditoUnlocked = false
};

            File.WriteAllText(UDPath, JsonConvert.SerializeObject(areaUnlocks, Newtonsoft.Json.Formatting.Indented));
        }

        internal static ProgressionData GetProgressionData()
        {
            string PDPath = Path.Combine(Utils.CommonVars.DataDir, "SaveData", "BaseProgression.json");
            ProgressionData progressionData = JsonConvert.DeserializeObject<ProgressionData>(File.ReadAllText(PDPath));
            return progressionData;
        }

        internal static void SetProgressionData(ProgressionData progressionData)
        {
            string PDPath = Path.Combine(Utils.CommonVars.DataDir, "SaveData", "BaseProgression.json");
            File.WriteAllText(PDPath, JsonConvert.SerializeObject(progressionData, Newtonsoft.Json.Formatting.Indented));
        }

        internal static void AddOrUpdateMission(string missionId, int missionState)
        {
            ProgressionData pData = GetProgressionData();

            var missionList = pData.Missions.ToList();

            MissionStateObject existingMission = missionList.FirstOrDefault(m => m.MissionId == missionId);

            if (existingMission != null)
            {
                existingMission.MissionState = missionState;
            }
            else
            {
                MissionStateObject newMission = new()
{
    MissionId = missionId,
    MissionState = missionState
};
                missionList.Add(newMission);
            }

            pData.Missions = missionList.ToArray();
            SetProgressionData(pData);
        }

        public static int? GetMissionState(string missionId)
        {
            ProgressionData pData = GetProgressionData();

            MissionStateObject mission = pData.Missions.FirstOrDefault(m => m.MissionId == missionId);

            return mission?.MissionState;
        }

        internal static int GetCoins()
        {
            return GetProgressionData().TotalCoins;
        }

        internal static int GetGoldStars()
        {
            return GetProgressionData().GoldStars;
        }

        internal static void UpdateCoins(int coinCount)
        {
            ProgressionData progressionData = GetProgressionData();
            int currentCoins = progressionData.TotalCoins;
            progressionData.TotalCoins = currentCoins + coinCount;
            SetProgressionData(progressionData);
        }
    }
}
