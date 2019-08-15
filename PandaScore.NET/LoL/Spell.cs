using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    public class Spell
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            var spells = obj as Spell;
            return spells != null &&
                   Id == spells.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
