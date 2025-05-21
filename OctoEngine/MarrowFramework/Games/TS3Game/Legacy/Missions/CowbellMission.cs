using Il2CppSLZ.Marrow.Interaction;
using OctoEngine.MarrowFramework;
using OctoEngine.MarrowFramework.Internal;
using OctoEngine.MarrowFramework.Internal.Helpers;
using UnityEngine;

namespace AuroraFramework.TS3Game.Missions
{
    public class CowbellMission : MonoBehaviour
    {
        private CowbellManager CowBellMan;

        private void Start()
        {
            CowBellMan = GameObject.Find("CowbellManager").GetComponent<CowbellManager>();
            // DLLMain.HookUnlockMissions(); // Here, we hook onto a start method to avoid recompiling.
        }

        public void TriggerCowbell()
        {
            if (SaveGameHelper.ReadData("Missions/" + "mission_findcowbells" + "/State") == "1")
            {
                CowBellMan.TriggerCowbell();
                GetComponentInParent<MarrowEntity>().Despawn();
            }
            else
            {
                ModLog.LogWarn("Tried to commence mission action (cowbell_find), but mission has not yet started. Ignoring...");
            }
        }

#if MELONLOADER
        public CowBellMission(IntPtr ptr) : base(ptr) { }
#endif
    }
}