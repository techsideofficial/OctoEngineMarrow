using Il2CppTMPro;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Base
{
    public class DeveloperWaypoint : MonoBehaviour
    {
        public string Name = "Waypoint";
#if UNITY_EDITOR
        [Header("Visual Settings")]
#endif
        public bool BeamVisibility = true;
        public bool BaseVisibility = true;
#if UNITY_EDITOR
        [Header("Text Settings")]
#endif
        public bool TextEnabled;
#if UNITY_EDITOR
        [Header("Audio Settings")]
#endif
        public bool AmbienceEnabled;
        public AudioClip Ambience;
#if UNITY_EDITOR
        [Header("Object Settings (DO NOT EDIT)")]
#endif
        public GameObject WaypointBeam;
        public GameObject WaypointBase;
        public AudioSystem WaypointAudioSystem;
        public TextMeshPro Text;


        private void Start()
        {
            WaypointBeam.SetActive(BeamVisibility);
            WaypointBase.SetActive(BaseVisibility);
            if (TextEnabled) { Text.text = Name; }
            if (AmbienceEnabled)
            {
                WaypointAudioSystem.Clips.Add(Ambience);
                WaypointAudioSystem.PlayMusic();
            }
        }

#if MELONLOADER
        public DeveloperWaypoint(IntPtr ptr) : base(ptr) { }
#endif
    }
}