using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class LeaderboardHaystackResponse
    {
        public string prev_cursor { get; set; }
        public string next_cursor { get; set; }
        public int rank_count { get; set; }
        public List<string> owner_records { get; set; }
        public List<LeaderboardHaystackRecord> records { get; set; }
    }

    public class LeaderboardHaystackRecord
    {
        public string display_name { get; set; }
        public string owner_id { get; set; }
        public string owner_discord_id { get; set; }
        public int rank { get; set; }
        private double _score;
        public double score
        {
            get => _score / 1_000_000_000; // Always divide when getting
            set => _score = value; // Store the original value
        }
        public int num_score { get; set; }
        public int create_time { get; set; }
        public int update_time { get; set; }
        public int expire_time { get; set; }
        public object metadata { get; set; }   
    }

    public class HaystackRecordSendTime
    {
        public string DiscordUserId { get; set; }
        public int Rank { get; set; }
        public string DisplayName { get; set; }
        public double Score { get; set; }
    }
}
