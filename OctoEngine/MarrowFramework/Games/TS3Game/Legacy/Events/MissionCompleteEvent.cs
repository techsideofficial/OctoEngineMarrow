using Il2CppSLZ.Marrow;
using UnityEngine;

namespace AuroraFramework.TS3Game.Events
{
    public class MissionCompleteEvent : MonoBehaviour
    {
        public AudioSource FireworkSFX;

        public void CompleteMission()
        {
            transform.position = FindObjectOfType<RigManager>().transform.position;
            FireworkSFX.Play();
        }

#if MELONLOADER
        public MissionCompleteEvent(IntPtr ptr) : base(ptr) { }
#endif
    }
}