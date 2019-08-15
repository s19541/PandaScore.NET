using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    public class Team
    {
        #region Properties
        [JsonProperty("acronym")]
        public string Acronym { get; private set; }
        [JsonProperty("current_videogame")]
        public VideoGame CurrentVideoGame { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        [JsonProperty("players")]
        public Player[] Players { get; private set; }
        #endregion

        #region Constructors
        public Team() { }
        #endregion

        #region Equals_HashCode
        public override bool Equals(object obj)
        {
            var team = obj as Team;
            return team != null &&
                   Id == team.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
        #endregion

    }
}
