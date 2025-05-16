using UnityEngine;

namespace AuroraFramework.TS3Game.Stagecoach
{
    public class StagecoachAnimator : MonoBehaviour
    {
        public AnimationClip MoveToStage;
        public AnimationClip MoveFromStageToEnd;
        public float MoveToStageDelay;
        public float MoveFromStageToEndDelay;
        public Animator MainAnimator;
        public bool HasWalkAnimation;

        private void Start()
        {
            MoveToStageDelay = MoveToStage.length;
            MoveFromStageToEndDelay = MoveFromStageToEnd.length;
        }
        public void StgStart()
        {
            MainAnimator.SetTrigger("StartStage");
        }

        public void StgEnd()
        {
            MainAnimator.SetTrigger("EndStage");
            if (HasWalkAnimation)
            {
                MainAnimator.SetBool("IsWalking", false);
            }
        }

        public void StgMoveToStage()
        {
            MainAnimator.SetTrigger("MoveToStage");
            if (HasWalkAnimation)
            {
                MainAnimator.SetBool("IsWalking", true);
            }
        }

        public void StgMoveFromStageToEnd()
        {
            MainAnimator.SetTrigger("MoveFromStageToEnd");
            if (HasWalkAnimation)
            {
                MainAnimator.SetBool("IsWalking", true);
            }
        }

        public void StgStageIdle()
        {
            MainAnimator.SetTrigger("AtStageIdle");
            MainAnimator.SetBool("IsWalking", false);
        }

#if MELONLOADER
        public StagecoachAnimator(IntPtr ptr) : base(ptr) { }
#endif
    }
}