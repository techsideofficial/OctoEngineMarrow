using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Marrow.Interaction;
using Il2CppSLZ.Marrow.Warehouse;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
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
        public AudioSource PingSFX;

        private int _currentObjectCount;

        public void ObjectEnteredZone(MarrowEntity entity)
        {
            _currentObjectCount++;
            ModLog.LogMessage("Object entered zone. Current count: " + _currentObjectCount);
            PingSFX.Play();
            if (_currentObjectCount >= RequiredObjectCount)
            {
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
