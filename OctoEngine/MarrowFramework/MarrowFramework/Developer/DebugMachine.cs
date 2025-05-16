#if UNITY
using TMPro;
#else
using Il2CppTMPro;
#endif
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Developer
{
    public class DebugMachine : MonoBehaviour
    {
        public TextMeshPro MissionDisplay;

        private List<Mission> _MList;

        private Mission _currentMission;

        private int _currentMissionCounter;

        private MissionSystem _missionGiver;

        private void Start()
        {
            _missionGiver = GetComponentInChildren<MissionSystem>();
            _MList = MissionManager.LoadMissionData();
            _currentMissionCounter = 0;

            if (_MList != null && _MList.Count > 0)
            {
                _currentMission = _MList[_currentMissionCounter];
                MissionDisplay.text = _currentMission.Name;
            }
            else
            {
                Debug.LogWarning("Mission list is empty or failed to load.");
            }
        }

        public void CycleNext()
        {
            if (_MList == null || _MList.Count == 0) return;

            _currentMissionCounter = (_currentMissionCounter + 1) % _MList.Count;
            _currentMission = _MList[_currentMissionCounter];
            MissionDisplay.text = _currentMission.Name;
        }

        public void CyclePrev()
        {
            if (_MList == null || _MList.Count == 0) return;

            _currentMissionCounter = (_currentMissionCounter - 1 + _MList.Count) % _MList.Count;
            _currentMission = _MList[_currentMissionCounter];
            MissionDisplay.text = _currentMission.Name;
        }

        public void Select()
        {
            if (_missionGiver == null)
            {
                Debug.LogWarning("Mission giver not assigned.");
                return;
            }

            if (_currentMission != null)
            {
                _missionGiver.MissionId = _currentMission.Id;
                _missionGiver.GiveMission();
            }
            else
            {
                Debug.LogWarning("No mission selected.");
            }
        }

#if MELONLOADER
        public DebugMachine(IntPtr ptr) : base(ptr) { }
#endif
    }
}
