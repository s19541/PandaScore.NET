using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET
{
    public class VideoGameVersion
    {
        [JsonProperty("current")]
        public bool Current { get; }
        [JsonProperty("name")]
        public string Name { get; }
    }
}
