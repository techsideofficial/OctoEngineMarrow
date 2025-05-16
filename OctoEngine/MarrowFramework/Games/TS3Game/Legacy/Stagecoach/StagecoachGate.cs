using UnityEngine;

namespace AuroraFramework.TS3Game.Stagecoach
{
    public class StageCoachGate : MonoBehaviour
    {
        public AnimationClip EntryDoorAnim;
        public AnimationClip ExitDoorAnim;
        public Animator DoorAnimator;
        public bool DisableGameObjectMode;
        public GameObject EntryDoorGO;
        public GameObject ExitDoorGO;

        public void PlayDoorAnim(bool IsEntryDoor)
        {
            if (IsEntryDoor)
            {
                DoorAnimator.Play(EntryDoorAnim.name);
            }
            else
            {
                DoorAnimator.Play(ExitDoorAnim.name);
            }
        }

        public void EntryDoorOpen()
        {
            EntryDoorGO.SetActive(false);
        }

        public void EntryDoorClose()
        {
            EntryDoorGO.SetActive(true);
        }

        public void ExitDoorOpen()
        {
            ExitDoorGO.SetActive(false);
        }

        public void ExitDoorClose()
        {
            ExitDoorGO.SetActive(true);
        }

#if MELONLOADER
        public StageCoachGate(IntPtr ptr) : base(ptr) { }
#endif
    }
}