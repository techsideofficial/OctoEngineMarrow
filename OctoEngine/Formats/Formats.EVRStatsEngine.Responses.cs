using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class EVRStatsCombatSelfPerGame
    {
        public int GamesPlayed { get; set; }
        public double CombatHeadshotKillsPerGame { get; set; }
        public double CombatEliminationsPerGame { get; set; }
        public double CombatSoloKillsPerGame { get; set; }
        public double CombatDeathsPerGame {  get; set; }
    }

    public class EVRStatsCombatSelfTotal
    {
        public int GamesPlayed { get; set; }
        public int CombatHeadshotKills { get; set; }
        public int CombatEliminations { get; set; }
        public int CombatSoloKills { get; set; }
        public int CombatDeaths { get; set; }
    }
}
