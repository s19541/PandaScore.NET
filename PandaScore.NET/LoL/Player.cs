using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public enum PlayerRole { top, jun, mid, adc, sup }

    public class Player
    {
        #region Properties
        [JsonProperty("current_team")]
        public Team CurrentTeam { get; private set; }
        [JsonProperty("first_name")]
        public string FirstName { get; private set; }
        [JsonProperty("hometown")]
        public string Country { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; }
        [JsonProperty("last_name")]
        public string LastName { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("role")]
        public PlayerRole Role { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        #endregion

        #region Constructors
        public Player() { }
        #endregion

        #region Equals_HashCode
        public override bool Equals(object obj)
        {
            var player = obj as Player;
            return player != null &&
                   Id == player.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        } 
        #endregion
    }
}
