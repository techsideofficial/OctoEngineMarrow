using Il2CppSLZ.Marrow.Interaction;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using System.Collections.Generic;
using UnityEngine;

namespace AuroraFramework.TS3Game.Missions
{
    public class FourCowsMission : MonoBehaviour
    {
        public AudioSource PingSfx;

        private static List<string> CowTags = new List<string>();

        public void TriggerCow(MarrowEntity spawnable)
        {
            MissionSystem MissionComplete = GetComponent<MissionSystem>();

            if (spawnable.Tags.Tags.Count > 0 && !CowTags.Contains(spawnable.Tags.Tags[0].Barcode.ID) && SaveGame.ReadData("Missions/" + "mission_delivercows1" + "/State") == "1")
            {
                CowTags.Add(spawnable.Tags.Tags[0].Barcode.ID);
                MissionComplete.DoMission();

                ModLog.LogMessage(spawnable.gameObject.name + ".Tags.Tags[0] = " + spawnable.Tags.Tags[0].Barcode.ID);

                PingSfx.Play();
            }

            if (CowTags.Count == 4)
            {
                CowTags.Clear();
                ModLog.LogMessage("CowTags list cleared after reaching 4 entries.");
            }
        }

#if MELONLOADER
        public FourCowsMission(IntPtr ptr) : base(ptr) { }
#endif
    }
}