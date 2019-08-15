using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    public class Winner
    {
        [JsonProperty("id")]
        public int ID { get; private set; }
        [JsonProperty("type")]
        public string Type { get; private set; }

        public override bool Equals(object obj)
        {
            var winner = obj as Winner;
            return winner != null &&
                   ID == winner.ID &&
                   Type == winner.Type;
        }

        public override int GetHashCode()
        {
            var hashCode = 430596813;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            return hashCode;
        }
    }
}
