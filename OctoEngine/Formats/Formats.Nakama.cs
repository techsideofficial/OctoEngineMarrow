using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class NakamaStatsResponse
    {
        public Stats stats { get; set; }
    }

    public class NakamaLookup
    {
        public string id { get; set; }
        public string discord_id { get; set; }
        public string username { get; set; }
        public string display_name { get; set; }
        public string avatar_url { get; set; }
    }
}
