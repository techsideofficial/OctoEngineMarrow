using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Marrow.Audio;
using UnityEngine;
using UnityEngine.Audio;

namespace OctoEngine.MarrowFramework.Games.Legacy
{
    public class AudioSourceChannel : MonoBehaviour
    {
        public enum mixerGroups
        {
            hardInteraction = 0,
            softInteraction = 1,
            impact = 2,
            ambience = 3,
            diegeticMusic = 4,
            npcVocals = 5
        }

        public mixerGroups AudioMixerGroups;

        private AudioMixerGroup GetAudioMixer()
        {
            switch (AudioMixerGroups)
            {
                case mixerGroups.hardInteraction:
                    return Audio3dManager.hardInteraction;
                case mixerGroups.softInteraction:
                    return Audio3dManager.softInteraction;
                case mixerGroups.impact:
                    return Audio3dManager.impact;
                case mixerGroups.ambience:
                    return Audio3dManager.ambience;
                case mixerGroups.diegeticMusic:
                    return Audio3dManager.diegeticMusic;
                case mixerGroups.npcVocals:
                    return Audio3dManager.npcVocals;
                default:
                    return Audio3dManager.impact;
            }
        }

        private void Awake()
        {
            this.GetComponent<AudioSource>().outputAudioMixerGroup = GetAudioMixer();
        }
    }
}
