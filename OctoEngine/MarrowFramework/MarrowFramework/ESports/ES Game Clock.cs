using Il2CppTMPro;
using UnityEngine;

namespace OctoEngine.MarrowFramework.ESports
{
    public class ES_Game_Clock : MonoBehaviour
    {
        public TextMeshPro Clock;
        public TextMeshPro Team1Score;
        public TextMeshPro Team2Score;

        private void Start()
        {
            Clock.text = "00:00:00";
            Team1Score.text = "00";
            Team2Score.text = "00";
        }

#if MELONLOADER
        public ES_Game_Clock(IntPtr ptr) : base(ptr) { }
#endif
    }
}
