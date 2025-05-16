using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class RecordSendTime
    {
        public string NakamaId { get; set; }
        public int Rank { get; set; }
        public string DisplayName { get; set; }
        public double Score { get; set; }
    }

    // PARSING FROM NAKAMA
    public class LeaderboardRecordResponse
    {
        public string leaderboard_id { get; set; }
        public string next_cursor { get; set; }
        public string prev_cursor { get; set; }
        public List<LeaderboardRecord> records { get; set; }
    }

    public class LeaderboardRecord
    {
        public string owner_id { get; set; }
        public RecordValueObject username { get; set; }
        private double _score;
        public double score
        {
            get => _score / 1_000_000_000; // Always divide when getting
            set => _score = value; // Store the original value
        }
        public int num_score { get; set; }
        public RecordTimeSecondsObject create_time { get; set; }
        public RecordTimeSecondsObject update_time { get; set; }
        public int rank { get; set; }
        public double max_num_score { get; set; }
        public object metadata { get; set; }
    }

    public class RecordValueObject
    {
        public string value { get; set; }
    }

    public class RecordTimeSecondsObject
    {
        public double seconds { get; set; }
    }
}
