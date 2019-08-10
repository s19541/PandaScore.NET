using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class League
    {
        #region Properties
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; }
        [JsonProperty("live_supported")]
        public bool LiveSupported { get; private set; }
        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("series")]
        public Series[] Series { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }
        #endregion

        #region Equals_HashCode
        public override bool Equals(object obj)
        {
            var league = obj as League;
            return league != null &&
                   Id == league.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
        #endregion

    }
}
