using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET
{
    public class LiveData
    {
        [JsonProperty("opens_at")]
        public string OpensAt { get; private set; }
        [JsonProperty("supported")]
        public bool? Supported { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }
    }
}
