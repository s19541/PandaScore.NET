using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class Spells
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("image_url")]
        public int ImageUrl { get; private set; }
        [JsonProperty("name")]
        public int Name { get; private set; }

        public override bool Equals(object obj)
        {
            var spells = obj as Spells;
            return spells != null &&
                   Id == spells.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
