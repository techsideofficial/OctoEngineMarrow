using UnityEngine;

namespace AuroraFramework.TS3Game.Stagecoach
{
    public class StagecoachGiftData : MonoBehaviour
    {
        public List<GameObject> GiftItems;

#if MELONLOADER
        public StagecoachGiftData(IntPtr ptr) : base(ptr) { }
#endif
    }
}