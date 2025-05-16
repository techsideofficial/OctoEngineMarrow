using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using UnityEngine;

namespace OctoEngine.MarrowFramework.MissionTypes
{
#if UNITY_EDITOR
    [RequireComponent(typeof(MissionSystem))]
#endif
    public class MissionType_CollectObjects : MonoBehaviour
    {
        public int RequiredObjectCount;
        public AudioSource PingSFX;

        private int _currentObjectCount;

        public void ObjectCollected()
        {
            _currentObjectCount++;
            ModLog.LogMessage("Object collected. Current count: " + _currentObjectCount);
            PingSFX.Play();
            if (_currentObjectCount >= RequiredObjectCount)
            {
                GetComponent<MissionSystem>().DoMission();
                _currentObjectCount = 0; // Reset the count after mission completion
            }
        }

#if MELONLOADER
        public MissionType_CollectObjects(IntPtr ptr) : base(ptr) { }
#endif
    }
}
