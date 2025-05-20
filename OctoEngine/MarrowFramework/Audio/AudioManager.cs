using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoneLib.BoneMenu;
using Il2CppSLZ.Bonelab;
using Il2CppSLZ.Marrow.Audio;
using UnityEngine;
using OctoEngine.MarrowFramework.Internal;

namespace OctoEngine.MarrowFramework.Audio
{
    internal class AudioManager
    {
        public static void OnVolumeChanged(OCppTypes.mixers mixer, float value)
        {
            if (mixer == OCppTypes.mixers.audio_Music)
            {
                OCppConstants.fmodsys.SetMixerVolume(OctoEngine.Audio.FMODAudioSystem.MixerType.Bus, "bus:/Music", value);
            }
            else if (mixer == OCppTypes.mixers.audio_SFX)
            {
                OCppConstants.fmodsys.SetMixerVolume(OctoEngine.Audio.FMODAudioSystem.MixerType.Bus, "bus:/SFX", value);
            }
        }
    }
}
