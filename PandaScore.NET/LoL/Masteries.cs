using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class Masteries
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("name")]
        public int Name { get; private set; }

        public override bool Equals(object obj)
        {
            var masteries = obj as Masteries;
            return masteries != null &&
                   Id == masteries.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
