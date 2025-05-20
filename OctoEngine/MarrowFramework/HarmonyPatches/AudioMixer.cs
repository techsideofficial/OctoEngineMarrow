using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using Il2CppSLZ.Marrow.Audio;
using Il2CppSystem.Reflection;
using OctoEngine.MarrowFramework.Audio;
using OctoEngine.MarrowFramework.Internal;
using UnityEngine.Audio;

namespace OctoEngine.MarrowFramework.HarmonyPatches
{
    [HarmonyPatch(typeof(AudioMixer), "SetFloat")]
    public class AudioMixerFloatDebugPatch
    {
        public static void Prefix(AudioMixer __instance, string name, float value)
        {
            switch(name)
            {
                case "audio_Music":
                    AudioManager.OnVolumeChanged(OCppTypes.mixers.audio_Music, value);
                    break;
                case "audio_SFX":
                    AudioManager.OnVolumeChanged(OCppTypes.mixers.audio_SFX, value);
                    break;
            }
        }
    }
}
