using System.Collections;
using MelonLoader;
using OctoEngine.MarrowFramework.Base;
using OctoEngine.MarrowFramework.Internal;
using UnityEngine;

namespace AuroraFramework.TS3Game.Stagecoach
{
    public class StagecoachManager : MonoBehaviour
    {
        private StagecoachAnimator stagecoachAnimator;
        private AudioSystem musicZonePlayer;
        private StageCoachGate gateController;
        private AudioSystem clipProxy;

        public GameObject GiftBox;
        public GameObject StagecoachGiftAnchor;
        public GameObject StageGiftTarget;
        public GameObject Gate;
        public GameObject AuroraMusicZone;
        public AudioSource StagecoachMusic;
        public bool HasGift;
        public float DropoffDelay = 1f;

        private void Start()
        {
            stagecoachAnimator = GetComponent<StagecoachAnimator>();
            musicZonePlayer = AuroraMusicZone.GetComponent<AudioSystem>();
            gateController = Gate.GetComponent<StageCoachGate>();
            clipProxy = GetComponentInChildren<AudioSystem>();
            ModLog.LogMessage("LogShit");
        }

        public void StartSequence()
        {
            if (HasGift)
            {
                AttachGiftToAnchor();
            }
            musicZonePlayer.StopMusic();
            StagecoachMusic.Play();
#if UNITY_EDITOR
            StartCoroutine(PlayLoopedAudio());
            StartCoroutine(EntryDoorSequence());
            StartCoroutine(GoToStageSequence());
#else
            MelonCoroutines.Start(PlayLoopedAudio());
            MelonCoroutines.Start(EntryDoorSequence());
            MelonCoroutines.Start(GoToStageSequence());
#endif
        }

        public void MidSequenceDropoff()
        {
            StopStagecoachAudio();
#if UNITY_EDITOR
            StartCoroutine(DelayedGiftDropoff());
#else
            MelonCoroutines.Start(DelayedGiftDropoff());
#endif
            stagecoachAnimator.StgStageIdle();
            if (HasGift)
            {
                DropGiftAtTarget();
            }
        }

        public void EndSequence()
        {
#if UNITY_EDITOR
            StartCoroutine(PlayLoopedAudio());
            StartCoroutine(LeaveStageSequence());
            StartCoroutine(ExitDoorSequence());
#else
            MelonCoroutines.Start(PlayLoopedAudio());
            MelonCoroutines.Start(LeaveStageSequence());
            MelonCoroutines.Start(ExitDoorSequence());
#endif
            stagecoachAnimator.StgMoveFromStageToEnd();
        }

        private void AttachGiftToAnchor()
        {
            GiftBox.GetComponent<StagecoachGiftBox>().GiftTravel();
            GiftBox.transform.SetPositionAndRotation(StagecoachGiftAnchor.transform.position, StagecoachGiftAnchor.transform.rotation);
            GiftBox.transform.parent = StagecoachGiftAnchor.transform;
        }

        private void DropGiftAtTarget()
        {
            GiftBox.transform.SetPositionAndRotation(StageGiftTarget.transform.position, StageGiftTarget.transform.rotation);
            GiftBox.transform.parent = StageGiftTarget.transform;
            // GiftItem.GetComponent<StagecoachGiftItem>().BoxEnablePhysics();
        }

        private void StopStagecoachAudio()
        {
            clipProxy.StopMusic();
        }

        private IEnumerator DelayedGiftDropoff()
        {
            yield return new WaitForSeconds(DropoffDelay);
            EndSequence();
        }

        private IEnumerator GoToStageSequence()
        {
            stagecoachAnimator.StgStart();
            yield return new WaitForSeconds(0.5f);
            stagecoachAnimator.StgMoveToStage();
            yield return new WaitForSeconds(stagecoachAnimator.MoveToStageDelay);
            MidSequenceDropoff();
        }

        private IEnumerator LeaveStageSequence()
        {
            yield return new WaitForSeconds(stagecoachAnimator.MoveFromStageToEndDelay);
            stagecoachAnimator.StgEnd();
            yield return new WaitForSeconds(0.5f);
            stagecoachAnimator.StgStageIdle();
            musicZonePlayer.PlayMusic();
        }

        private IEnumerator EntryDoorSequence()
        {
            gateController.EntryDoorOpen();
            yield return new WaitForSeconds(3);
            gateController.EntryDoorClose();
        }

        private IEnumerator ExitDoorSequence()
        {
            gateController.ExitDoorOpen();
            yield return new WaitForSeconds(7);
            gateController.ExitDoorClose();
            StopStagecoachAudio();
        }

        private IEnumerator PlayLoopedAudio()
        {
            yield return new WaitForSeconds(0.1f);
            clipProxy.PlayOneShot("sx_stagecoach_loop1");
        }

#if MELONLOADER
        public StagecoachManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}
