using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

    public class NS
    {
        [JsonProperty("api")]
        public string APIUrl { get; set; }
        [JsonProperty("bugreporter")]
        public string BugReporterUrl { get; set; }
        [JsonProperty("carmel")]
        public string CarmelUrl { get; set; }
        [JsonProperty("aurora")]
        public string AuroraUrl { get; set; }
        [JsonProperty("stapi")]
        public string StAPIUrl { get; set; }
        [JsonProperty("mae")]
        public string MaeNetUrl { get; set; }
    }

    public enum NSUrl
    {
        API = 0,
        BugReporter = 1,
        Carmel = 2,
        Aurora = 3,
        StAPI = 4,
        MaeNet = 5,
    }
}
