using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Marrow.Interaction;
using Il2CppSLZ.Marrow.Warehouse;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using OctoEngine.MarrowFramework.Internal.Helpers;
using UnityEngine;

namespace OctoEngine.MarrowFramework.MissionTypes
{
#if UNITY_EDITOR
    [RequireComponent(typeof(MissionSystem))]
#endif
    public class MissionType_ZoneContainment : MonoBehaviour
    {
        public int RequiredObjectCount;
        public BoneTagReference ObjectTag;
        public AudioClip ObjectCollectPing;

        private int _currentObjectCount;
        private bool _missionComplete;
        private AudioSource a;

        private void Start()
        {
            a = GameObjectHelpers.CreateAudioSource(AudioMixerFixer.mixerGroups.impact);
            a.clip = ObjectCollectPing;
            _missionComplete = false;
        }

        public void ResetMission()
        {
            _currentObjectCount = 0;
            _missionComplete = false;
            ModLog.LogMessage("Mission reset. Current count: " + _currentObjectCount);
        }

        public void ObjectEnteredZone(MarrowEntity entity)
        {
            ModLog.LogMessage("Object entered zone. Current count: " + _currentObjectCount);
            if (!_missionComplete)
            {
                a.Play();
                _currentObjectCount++;
            }

            if (_currentObjectCount >= RequiredObjectCount)
            {
                _missionComplete = true;
                GetComponent<MissionSystem>().DoMission();
                _currentObjectCount = 0; // Reset the count after mission completion
            }
        }

        public void ObjectLeftZone(MarrowEntity entity)
        {
            _currentObjectCount--;
            ModLog.LogMessage("Object left zone. Current count: " + _currentObjectCount);
        }

#if MELONLOADER
        public MissionType_ZoneContainment(IntPtr ptr) : base(ptr) { }
#endif
    }
}
