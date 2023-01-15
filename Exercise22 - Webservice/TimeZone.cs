using System;
using Newtonsoft.Json;

namespace TimeZone
{
    public class TimeZone
    {
        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("gmtOffset")]
        public string GMTOffset { get; set; }
    }
}

