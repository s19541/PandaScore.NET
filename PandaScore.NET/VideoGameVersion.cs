using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET
{
    public class VideoGameVersion
    {
        [JsonProperty("current")]
        public bool Current { get; private set; }
        [JsonProperty("name")]
        public Version Name { get; private set; }
    }
}
