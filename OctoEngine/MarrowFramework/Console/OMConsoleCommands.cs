using OctoEngine.MarrowFramework.Internal;

namespace OctoEngine.MarrowFramework.Console
{
    internal static class OMConsoleCommands
    {
        [OMCommand("mission_activate")]
        public static string UnlockMission(string[] args)
        {
            if (args.Length == 0) return "Error: No mission ID provided.";
            var missionId = args[0];

            SaveGame.WriteValue("Missions/" + missionId + "/State", "1");
            NotificationHelper.InfoNotification(MissionManager.GetMission(missionId).Name, MissionManager.GetMission(missionId).Description, 5);
            ModLog.LogMessage(String.Concat("Successfully set missionstate of ", missionId, " to InProgress"));

            return $"Activated mission '{missionId}' unlocked.";
        }

        [OMCommand("mission_activateall")]
        public static string ActivateAllMissions(string[] args)
        {
            List<Mission> missions = MissionManager.LoadMissionData();
            foreach (Mission mission in missions)
            {
                SaveGame.WriteValue("Missions/" + mission.Id + "/State", "1");
            }
            return "All missions activated.";
        }
    }
}
