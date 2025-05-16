using Il2CppSLZ.SFX;
using OctoEngine.MarrowFramework.Internal;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Base
{
    public class MissionSystem : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("SFX is only required for mission complete.")]
#endif
        public SimpleSFX sfxP;

        public string MissionId;

        private string _tempName;

        private void Awake()
        {

        }

        public void GiveMission()
        {
            MissionManager.GiveMission(MissionId);
        }

        public void DoMission()
        {
            if (SaveGame.ReadData("Missions/" + MissionId + "/State") == "1")
            {
                // Multitrigger support removed due to script optimization with different mission types.
                SaveGame.WriteValue("Missions/" + MissionId + "/State", "2");
                SaveGame.WriteValue("Coins", (Int32.Parse(SaveGame.ReadData("Coins")) + MissionManager.GetMission(MissionId).CoinsAwarded).ToString());

                ModLog.LogMessage(String.Concat("Misson ", MissionId, " completed!"));

                string missionName = MissionManager.GetMission(MissionId).Name;

                NotificationHelper.IconNotification(
                    "Mission Completed!",
                    missionName,
                    5,
                    "bl_icon_missioncomplete.png"
                );

                sfxP.RANDOMPLAY();
            }
            else
            {
                ModLog.LogWarn(String.Concat("Mission ", MissionId, " not active. Cannot complete."));
            }
        }

#if MELONLOADER
        public MissionSystem(IntPtr ptr) : base(ptr) { }
#endif
    }
}
