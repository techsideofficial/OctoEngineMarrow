using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class Arena
    {
        public TabletStat ArenaLosses { get; set; }
        public TabletStat ArenaMVPPercentage { get; set; }
        public TabletStat ArenaTies { get; set; }
        public TabletStat ArenaWinPercentage { get; set; }
        public TabletStat ArenaWins { get; set; }
        public TabletStat Assists { get; set; }
        public TabletStat AssistsPerGame { get; set; }
        public TabletStat AveragePointsPerGame { get; set; }
        public TabletStat AveragePossessionTimePerGame { get; set; }
        public TabletStat AverageTopSpeedPerGame { get; set; }
        public TabletStat BlockPercentage { get; set; }
        public TabletStat Catches { get; set; }
        public TabletStat Clears { get; set; }
        public TabletStat CurrentArenaMVPStreak { get; set; }
        public TabletStat CurrentArenaWinStreak { get; set; }
        public TabletStat EarlyQuitPercentage { get; set; }
        public TabletStat GamesPlayed { get; set; }
        public TabletStat GoalSavePercentage { get; set; }
        public TabletStat GoalScorePercentage { get; set; }
        public TabletStat Goals { get; set; }
        public TabletStat GoalsPerGame { get; set; }
        public TabletStat HighestArenaMVPStreak { get; set; }
        public TabletStat HighestArenaWinStreak { get; set; }
        public TabletStat HighestPoints { get; set; }
        public TabletStat HighestSaves { get; set; }
        public TabletStat HighestStuns { get; set; }
        public TabletStat Interceptions { get; set; }
        public TabletStat Level { get; set; }
        public TabletStat LobbyTime { get; set; }
        public TabletStat Passes { get; set; }
        public TabletStat Points { get; set; }
        public TabletStat PossessionTime { get; set; }
        public TabletStat PunchesReceived { get; set; }
        public TabletStat RankPercentile { get; set; }
        public TabletStat Saves { get; set; }
        public TabletStat SavesPerGame { get; set; }
        public TabletStat ShotsOnGoal { get; set; }
        public TabletStat ShotsOnGoalAgainst { get; set; }
        public TabletStat SkillRatingMu { get; set; }
        public TabletStat SkillRatingSigma { get; set; }
        public TabletStat Steals { get; set; }
        public TabletStat StunPercentage { get; set; }
        public TabletStat Stuns { get; set; }
        public TabletStat StunsPerGame { get; set; }
        public TabletStat ThreePointGoals { get; set; }
        public TabletStat TopSpeedsTotal { get; set; }
        public TabletStat TwoPointGoals { get; set; }
        public TabletStat XP { get; set; }
    }

    public class ArenaPrivate
    {
        public TabletStat LobbyTime { get; set; }
    }

    public class Combat
    {
        public TabletStat CombatAssists { get; set; }
        public TabletStat CombatBestEliminationStreak { get; set; }
        public TabletStat CombatDamage { get; set; }
        public TabletStat CombatDamageTaken { get; set; }
        public TabletStat CombatDeaths { get; set; }
        public TabletStat CombatEliminations { get; set; }
        public TabletStat CombatHeadshotKills { get; set; }
        public TabletStat CombatHealing { get; set; }
        public TabletStat CombatKills { get; set; }
        public TabletStat CombatLosses { get; set; }
        public TabletStat CombatMVPs { get; set; }
        public TabletStat CombatObjectiveDamage { get; set; }
        public TabletStat CombatObjectiveEliminations { get; set; }
        public TabletStat CombatObjectiveTime { get; set; }
        public TabletStat CombatPayloadGamesPlayed { get; set; }
        public TabletStat CombatPayloadWinPercentage { get; set; }
        public TabletStat CombatPayloadWins { get; set; }
        public TabletStat CombatPointCaptureGamesPlayed { get; set; }
        public TabletStat CombatSoloKills { get; set; }
        public TabletStat CombatTeammateHealing { get; set; }
        public TabletStat CombatWinPercentage { get; set; }
        public TabletStat CombatWins { get; set; }
        public TabletStat Level { get; set; }
        public TabletStat LobbyTime { get; set; }
        public TabletStat RankPercentile { get; set; }
        public TabletStat SkillRatingMu { get; set; }
        public TabletStat SkillRatingSigma { get; set; }
        public TabletStat XP { get; set; }
    }

    public class CombatPrivate
    {
        public TabletStat LobbyTime { get; set; }
    }

    public class Social
    {
        public TabletStat LobbyTime { get; set; }
    }

    public class SocialPrivate
    {
        public TabletStat LobbyTime { get; set; }
    }

    public class TabletStat
    {
        public float val { get; set; }
        public string op { get; set; }
        public float cnt { get; set; }
    }

    public class Stats
    {
        public Arena arena { get; set; }
        public ArenaPrivate arena_private { get; set; }
        public Combat combat { get; set; }
        public CombatPrivate combat_private { get; set; }
        public Social social { get; set; }
        public SocialPrivate social_private { get; set; }
    }
}