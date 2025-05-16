using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public enum Region
    {
        OCE = 0,
        NA = 1,
        EU = 2,
        ASIA = 3,
        JPN = 4,
    }

    public class ASPContentResult
    {
        public string Content { get; set; }
        public string ContentType { get; set; }
        public int StatusCode { get; set; }
    }
}
