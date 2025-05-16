using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppTMPro;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Games.CartridgeMusicPlayer
{
    public class Cartridge : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("Cartridge Info")]
#endif
        public string? Title;
        public string? Author;
        public List<AudioClip>? Tracks;

#if UNITY_EDITOR
        [Header("Cartridge Settings (DO NOT EDIT THESE)")]
#endif
        public Transform AnchorPoint;
        public AudioSource SFXPlayer;
        public TextMeshPro TitleText;
        public TextMeshPro AuthorText;
        public TextMeshPro TrackText;

        private void Start()
        {
            SetText();
        }

        private List<string> GetTrackNames()
        {
            return (from track in Tracks select track.name).ToList();
        }

        private void SetText()
        {
            TitleText.text = Title;
            AuthorText.text = Author;
            List<string> trackNames = GetTrackNames();
            string trackList = "";

            foreach (string track in trackNames)
            {
                trackList += String.Concat(trackNames.IndexOf(track), ". ", track, "\n");
            }
            TrackText.text = trackList;
        }
    }
}
