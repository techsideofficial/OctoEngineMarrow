using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using System.Collections;
using UnityEngine;

namespace AuroraFramework.TS3Game.RubyRails
{
    // why did i do this shit? this code is a living hell
    public class RubyRailsManager : MonoBehaviour
    {
        public GameObject RailMusic;
        public GameObject RubyRailsSeatPositive;
        public string AnimationStateNamePositive;

        public GameObject RubyRailsSeatNegative;
        public string AnimationStateNameNegative;

        public GameObject RailObject;

        public bool RailLocked;

        public AnimationClip AnimMain;

        public float AnimationPostDelay;

        private float AnimLength;

        private float AnimAdj;



        private void Start()
        {
            AnimLength = AnimMain.length;
        }
        public void RailPositiveStart()
        {
            if (!RailLocked)
            {
                RailObject.GetComponent<MeshCollider>().enabled = false;
                RubyRailsSeatPositive.GetComponent<Animator>().Play(AnimationStateNamePositive);
                RubyRailsSeatPositive.GetComponent<RubyRailsSeater>().SeatPlayer();
                RailMusic.GetComponent<AudioSystem>().PlayOneShotRandom();
                RailLocked = true;
#if UNITY_EDITOR
                StartCoroutine(RailUnlocker());
#elif MELONLOADER
                MelonCoroutines.Start(RailUnlocker());
#endif
            }
        }

        public void RailPositiveEnd()
        {
            RubyRailsSeatPositive.GetComponent<RubyRailsSeater>().EjectPlayer();
            RailMusic.GetComponent<AudioSystem>().StopMusic();
            RailObject.GetComponent<MeshCollider>().enabled = true;
        }

        public void RailNegativeStart()
        {
            if (!RailLocked)
            {
                RailObject.GetComponent<MeshCollider>().enabled = false;
                RubyRailsSeatNegative.GetComponent<Animator>().Play(AnimationStateNameNegative);
                RubyRailsSeatNegative.GetComponent<RubyRailsSeater>().SeatPlayer();
                RailMusic.GetComponent<AudioSystem>().PlayOneShotRandom();
                RailLocked = true;
#if UNITY_EDITOR
                StartCoroutine(RailUnlocker());
#elif MELONLOADER
                MelonCoroutines.Start(RailUnlocker());
#endif
            }
        }

        public void RailNegativeEnd()
        {
            RubyRailsSeatNegative.GetComponent<RubyRailsSeater>().EjectPlayer();
            RailMusic.GetComponent<AudioSystem>().StopMusic();
            RailObject.GetComponent<MeshCollider>().enabled = true;
        }

        IEnumerator RailUnlocker()
        {
            AnimAdj = AnimLength + AnimationPostDelay;
            ModLog.LogMessage("Animation Length: " + AnimAdj);
            yield return new WaitForSeconds(AnimAdj);

            RailLocked = false;
            RubyRailsSeatPositive.GetComponent<Animator>().SetTrigger("idleani");
        }

#if MELONLOADER
        public RubyRailsManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}