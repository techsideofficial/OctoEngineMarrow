using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal.Helpers;
using UnityEngine;

namespace OctoEngine.MarrowFramework.MissionTypes
{
    public class MissionType_TimeTrial : MonoBehaviour
    {
        public float TimeLimit = 60f; // Time limit in seconds
        public AudioClip BeginSFX;
        public AudioClip TimerTick;
        public AudioClip SuccessSFX;
        public AudioClip FailureSFX;
        public List<GameObject> Collectables;

        private AudioSource _statusSfx;
        private AudioSource _timerSfx;
        private bool _isCountingDown;
        private float _timeRemaining;
        private int _collectableCountRemaining;

        private void Start()
        {
            _statusSfx = GameObjectHelpers.CreateAudioSource(AudioMixerFixer.mixerGroups.impact);
            _timerSfx = GameObjectHelpers.CreateAudioSource(AudioMixerFixer.mixerGroups.impact);
            _timerSfx.clip = TimerTick;
            foreach(var collectable in Collectables)
            {
                collectable.SetActive(false);
            }
        }

        public void CollectCollectable(GameObject cObject)
        {
            _collectableCountRemaining--;
            cObject.SetActive(false);
            if (_collectableCountRemaining <= 0)
            {
                _isCountingDown = false;
                _timeRemaining = TimeLimit;
                _statusSfx.clip = SuccessSFX;
                _statusSfx.Play();
            }
        }

        public void StartTimeTrial()
        {
            _statusSfx.clip = BeginSFX;
            _statusSfx.Play();
            _collectableCountRemaining = Collectables.Count;
            _timeRemaining = TimeLimit;
            _isCountingDown = true;
            foreach (var collectable in Collectables)
            {
                collectable.SetActive(true);
            }
            MelonCoroutines.Start(TimerTickSecond());
        }

        private void OnTimerFinished()
        {
            foreach (var collectable in Collectables)
            {
                collectable.SetActive(false);
            }
            _isCountingDown = false;
            _timeRemaining = TimeLimit;
            _statusSfx.clip = FailureSFX;
            _statusSfx.Play();
        }

        private IEnumerator TimerTickSecond()
        {
            while (_isCountingDown)
            {
                yield return new WaitForSeconds(1f);
                _timeRemaining = _timeRemaining - 1f;
                _timerSfx.Play();
            }
        }
    }
}
