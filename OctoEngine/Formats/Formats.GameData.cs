using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class AccountGameData
    {
        public GameModeration Moderation { get; set; }
        public SkillStats SkillStats { get; set; }

    }

    public class GameModeration
    {
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
        public string BanExpiry { get; set; }
        public int KickCount { get; set; }
    }

    public class SkillStats
    {
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public float TimePlayed { get; set; }
    }
}
