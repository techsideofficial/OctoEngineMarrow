using Il2CppSLZ.SFX;
using OctoEngine.MarrowFramework.Internal;
using OctoEngine.MarrowFramework.Internal.Helpers;
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
            MissionHelper.GiveMission(MissionId);
        }

        public void DoMission()
        {
            if (SaveGameHelper.ReadData("Missions/" + MissionId + "/State") == "1")
            {
                // Multitrigger support removed due to script optimization with different mission types.
                SaveGameHelper.WriteValue("Missions/" + MissionId + "/State", "2");
                SaveGameHelper.WriteValue("Coins", (Int32.Parse(SaveGameHelper.ReadData("Coins")) + MissionHelper.GetMission(MissionId).CoinsAwarded).ToString());

                ModLog.LogMessage(String.Concat("Misson ", MissionId, " completed!"));

                string missionName = MissionHelper.GetMission(MissionId).Name;

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
