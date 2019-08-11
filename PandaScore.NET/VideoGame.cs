using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET
{
    public struct VideoGame
    {
        [JsonProperty("current_version")]
        public string CurrentVersion { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
    }
}
