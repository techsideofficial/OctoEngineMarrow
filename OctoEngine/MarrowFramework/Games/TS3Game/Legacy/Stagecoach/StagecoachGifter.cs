using Il2CppSLZ.Marrow.Warehouse;
using UnityEngine;

namespace AuroraFramework.TS3Game.Stagecoach
{
    public class StagecoachGifter : MonoBehaviour
    {
        public SpawnableCrateReference Gift;
        public GameObject GiftBox;
        public GameObject StageCoach;

        public void GiftItem()
        {
            GiftBox.GetComponent<StagecoachGiftBox>().InitializeGift(Gift);
            StageCoach.GetComponent<StagecoachManager>().StartSequence();
        }

#if MELONLOADER
        public StagecoachGifter(IntPtr ptr) : base(ptr) { }
#endif
    }
}