using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppSLZ.Interaction;
using Il2CppSLZ.Marrow.Interaction;
using MelonLoader;
using OctoEngine.MarrowFramework.Base;
using UnityEngine;

namespace OctoEngine.MarrowFramework.Games.CartridgeMusicPlayer
{
    public class Console : MonoBehaviour
    {
        private GameObject? _cartridge;
        private AudioSystem _audioSystem;
        private object? _playlistCoToken;

        private void Start()
        {
            _audioSystem = GetComponentInChildren<AudioSystem>();
        }

        public void OnInsert()
        {
            KeyReceiver keyReciever = GetComponentInChildren<KeyReceiver>();
            try
            {
                _cartridge = keyReciever.marrowEntity.GetComponentInChildren<Cartridge>().gameObject;

                _audioSystem.Clips = _cartridge.GetComponent<Cartridge>().Tracks;
                _audioSystem.Initialize();

                _playlistCoToken = MelonCoroutines.Start(StartPlaylist());
            }
            catch
            {
                MarrowEntity cartridgeEntity = keyReciever.marrowEntity;
                keyReciever.Release();
                cartridgeEntity.GetComponentInChildren<Rigidbody>().AddForce(cartridgeEntity.gameObject.transform.up * 10f, ForceMode.Impulse);
            }
        }

        public void OnEject()
        {
            MelonCoroutines.Stop(_playlistCoToken);
        }

        private IEnumerator StartPlaylist()
        {
            foreach (AudioClip clip in _audioSystem.Clips)
            {
                _audioSystem.PlayOneShot(clip.name);
                yield return new WaitForSeconds(clip.length);
            }
        }
    }
}
