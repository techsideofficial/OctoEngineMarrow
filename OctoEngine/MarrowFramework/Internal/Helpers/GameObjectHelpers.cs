using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoEngine.MarrowFramework.Base;
using UnityEngine;
using UnityEngine.Audio;

namespace OctoEngine.MarrowFramework.Internal.Helpers
{
    internal class GameObjectHelpers
    {
        internal static AudioSource CreateAudioSource(AudioMixerFixer.mixerGroups mixerGroup)
        {
            AudioSource audioSource = new AudioSource();
            audioSource.gameObject.AddComponent<AudioMixerFixer>();
            audioSource.gameObject.GetComponent<AudioMixerFixer>().AudioMixerGroups = mixerGroup;
            return audioSource;
        }
    }
}
