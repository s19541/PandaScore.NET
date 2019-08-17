using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET
{
    public class MatchParticipantTeam
    {
        [JsonProperty("acronym")]
        public string Acronym { get; private set; }
        [JsonProperty("id")]
        public int? Id { get; private set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
    }
}
