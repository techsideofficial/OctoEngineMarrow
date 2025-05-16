using UnityEngine;

namespace OctoEngine.MarrowFramework.ESports
{
    public class ES_Goal : MonoBehaviour
    {
        public string GoalID;
        public string BallId;

#if MELONLOADER
        public ES_Goal(IntPtr ptr) : base(ptr) { }
#endif
    }
}
