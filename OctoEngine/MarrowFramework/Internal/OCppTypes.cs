using System.Drawing;

namespace OctoEngine.MarrowFramework.Internal
{
    public class OCppTypes
    {
        public enum mixerGroups
        {
            hardInteraction = 0,
            softInteraction = 1,
            impact = 2,
            ambience = 3,
            diegeticMusic = 4,
            npcVocals = 5
        }

        public enum mixers
        {
            audio_Music = 0,
            audio_SFX = 1
        }

        public class ES_TeamInfo
        {
            public string TeamId;
            public string TeamName;
            public Color TeamColor;
        }
    }
}
