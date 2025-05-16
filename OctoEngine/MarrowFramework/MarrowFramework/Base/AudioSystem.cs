#if UNITY
using SLZ.Marrow.Audio;
#else
using Il2CppSLZ.Marrow.Audio;
#endif
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using OctoEngine.MarrowFramework.Internal;
using MelonLoader;

namespace OctoEngine.MarrowFramework.Base
{
#if UNITY_EDITOR
    [RequireComponent(typeof(AudioSource))]
#endif
    public class AudioSystem : MonoBehaviour
    {
        public List<AudioClip> Clips;

        private AudioSource a;

        private List<string> ClipNames;
        private AudioClip _lastAudioClip;
        private AudioClip _currentAudioClip;
        private float AudioPlayerVolume;
        private bool _isPlaying;

        private void Awake()
        {
            a = this.GetComponent<AudioSource>();

            a.outputAudioMixerGroup = GetAudioMixer();

            Initialize();
        }


        public void Initialize()
        {
            foreach (AudioClip clip in Clips)
            {
                ClipNames.Add(clip.name);
            }
        }

        private void Start()
        {
            AudioPlayerVolume = a.volume;
        }

        public OCppTypes.mixerGroups AudioMixerGroup;

        private AudioMixerGroup GetAudioMixer()
        {
            switch (AudioMixerGroup)
            {
                case OCppTypes.mixerGroups.hardInteraction:
                    return Audio3dManager.hardInteraction;
                case OCppTypes.mixerGroups.softInteraction:
                    return Audio3dManager.softInteraction;
                case OCppTypes.mixerGroups.impact:
                    return Audio3dManager.impact;
                case OCppTypes.mixerGroups.ambience:
                    return Audio3dManager.ambience;
                case OCppTypes.mixerGroups.diegeticMusic:
                    return Audio3dManager.diegeticMusic;
                case OCppTypes.mixerGroups.npcVocals:
                    return Audio3dManager.npcVocals;
                default:
                    return null;
            }
        }

        public void PlayOneShot(string clipName)
        {
            try
            {
                a.clip = Clips[ClipNames.IndexOf(clipName)];
                a.Play();
            }
            catch
            {
                ModLog.LogError("MultiClipProxy - Clip name does not exist!");
            }
        }

        public void PlayOneShotRandom()
        {
            a.clip = Clips[UnityEngine.Random.Range(0, Clips.Count)];
            a.Play();
        }

        public void PlayMusic()
        {
            if (_isPlaying) return; // Prevent multiple calls to Play while already playing
            _isPlaying = true;
#if UNITY_EDITOR
            StartCoroutine(DoPlayMusic());
#else
            MelonCoroutines.Start(DoPlayMusic());
#endif
        }

        public void StopMusic()
        {
            if (!_isPlaying) return; // Prevent multiple calls to Stop while already stopped
            _isPlaying = false;
#if UNITY_EDITOR
            StartCoroutine(DoStopMusic());
#else
            MelonCoroutines.Start(DoStopMusic());
#endif
        }

        public void StopAllAudio()
        {
            a.Stop();
        }

        private IEnumerator DoPlayMusic()
        {
            a.volume = 0;

            while (a.volume < AudioPlayerVolume)
            {
                a.volume += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            PlayNextClip();
        }

        private IEnumerator DoStopMusic()
        {
            while (a.volume > 0)
            {
                a.volume -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            a.Stop();
            a.volume = AudioPlayerVolume;
        }

        private void PlayNextClip()
        {
            if (Clips.Count == 0 || !_isPlaying) return;

            // Select a new random clip that's not the same as the last one
            do
            {
                _currentAudioClip = Clips[UnityEngine.Random.Range(0, Clips.Count)];
            } while (Clips.Count > 1 && _currentAudioClip == _lastAudioClip);

            _lastAudioClip = _currentAudioClip;
#if UNITY_EDITOR
            StartCoroutine(BgMusicLoop());
#else
            MelonCoroutines.Start(BgMusicLoop());
#endif
        }

        private IEnumerator BgMusicLoop()
        {
            a.clip = _currentAudioClip;
            a.Play();

            // Wait until the current clip finishes playing before selecting the next one
            while (a.isPlaying && _isPlaying)
            {
                yield return null;
            }

            if (_isPlaying)
            {
                PlayNextClip();
            }
        }

#if MELONLOADER
        public AudioSystem(IntPtr ptr) : base(ptr) { }
#endif
    }
}
