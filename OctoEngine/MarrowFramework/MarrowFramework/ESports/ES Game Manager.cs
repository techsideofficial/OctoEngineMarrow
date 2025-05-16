using UnityEngine;

namespace OctoEngine.MarrowFramework.ESports
{
    public class ES_Game_Manager : MonoBehaviour
    {
        public string GameName;
        public List<ES_Goal> Goals;
        public List<ES_Game_Clock> GameClocks;

        private void UpdateGameClock(int hour, int minute, int second)
        {
            foreach (ES_Game_Clock clock in GameClocks)
            {
                clock.Clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
            }
        }

        private void UpdateTeam1Score(int score)
        {
            foreach (ES_Game_Clock clock in GameClocks)
            {
                clock.Team1Score.text = string.Format("{0:D2}", score);
            }
        }

        private void UpdateTeam2Score(int score)
        {
            foreach (ES_Game_Clock clock in GameClocks)
            {
                clock.Team2Score.text = string.Format("{0:D2}", score);
            }
        }

#if MELONLOADER
        public ES_Game_Manager(IntPtr ptr) : base(ptr) { }
#endif
    }
}
