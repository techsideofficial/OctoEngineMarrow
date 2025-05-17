using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using UnityEngine;

namespace AuroraFramework.TS3Game.Missions
{
    public class CowbellManager : MonoBehaviour
    {
        public AudioSource PingSource;
        private static int CowbellCount = 0;

        // this code can go die in a hole. it should have been replaced by now, but idk why it hasn't
        public void TriggerCowbell()
        {
            GetComponent<MissionSystem>().DoMission();
            PingSource.Play();
            CowbellCount++;
            ModLog.LogMessage("Found Cowbell");

            if (CowbellCount == 5)
            {
                ModLog.LogMessage("Cowbell mission complete, resetting cowbell count to 0...");
                CowbellCount = 0;
            }
        }

#if MELONLOADER
        public CowbellManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}