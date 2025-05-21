using OctoEngine.MarrowFramework.Internal;
using OctoEngine.MarrowFramework.Internal.Helpers;

namespace OctoEngine.MarrowFramework.Console
{
    // these aren't even used
    internal static class OMConsoleCommands
    {
        [OMCommand("mission_activate")]
        public static string UnlockMission(string[] args)
        {
            if (args.Length == 0) return "Error: No mission ID provided.";
            var missionId = args[0];

            SaveGameHelper.WriteValue("Missions/" + missionId + "/State", "1");
            NotificationHelper.InfoNotification(MissionHelper.GetMission(missionId).Name, MissionHelper.GetMission(missionId).Description, 5);
            ModLog.LogMessage(String.Concat("Successfully set missionstate of ", missionId, " to InProgress"));

            return $"Activated mission '{missionId}' unlocked.";
        }

        [OMCommand("mission_activateall")]
        public static string ActivateAllMissions(string[] args)
        {
            List<Mission> missions = MissionHelper.LoadMissionData();
            foreach (Mission mission in missions)
            {
                SaveGameHelper.WriteValue("Missions/" + mission.Id + "/State", "1");
            }
            return "All missions activated.";
        }
    }
}
