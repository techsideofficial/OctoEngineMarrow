using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Base
{
    public class OctoPlayerRig : MonoBehaviour
    {
        public string Username;
        public string PlayerMetadata;
        public AudioClip PingSFX;

        public void Ping()
        {
            PlayAudioClip(PingSFX);
        }

        public void PlayAudioClip(AudioClip clip)
        {
            AudioSystem a = this.GetComponentInChildren<AudioSystem>();
            a.Clips.Add(clip);
            a.PlayOneShotRandom();
            a.Clips.Clear();
        }

#if MELONLOADER
        public OctoPlayerRig(IntPtr ptr) : base(ptr) { }
#endif
    }
}
