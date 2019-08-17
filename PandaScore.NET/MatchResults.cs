using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET
{
    public class MatchResults
    {
        [JsonProperty("team_id")]
        public int? TeamId { get; private set; }
        [JsonProperty("score")]
        public int? Score { get; private set; }
    }
}
