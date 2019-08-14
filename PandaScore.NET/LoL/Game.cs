using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    /// <summary>
    /// Represents a single game of League of Legends.
    /// </summary>
    public class Game
    {
        #region Properties
        [JsonProperty("begin_at")]
        public DateTime BeginAt { get; private set; }
        [JsonProperty("end_at")]
        public DateTime EndAt { get; private set; }
        [JsonProperty("finished")]
        public bool Finished { get; private set; }
        [JsonProperty("forfeit")]
        public bool Forfeit { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("length")]
        public float Length { get; private set; }
        [JsonProperty("match")]
        public Match Match { get; private set; }
        [JsonProperty("match_id")]
        public int MatchId { get; private set; }
        [JsonProperty("players")]
        public Player[] Players { get; private set; }
        /// <summary>
        /// This game's position in a series.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("teams")]
        public Team[] Teams { get; private set; }
        [JsonProperty("video_url")]
        public string VideoUrl { get; private set; }
        [JsonProperty]
        public Winner Winner { get; private set; }
        [JsonProperty("winner_type")]
        public string WinnerType { get; private set; }
        #endregion

        #region Equals_HashCode
        public override bool Equals(object obj)
        {
            var game = obj as Game;
            return game != null &&
                   Id == game.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        } 
        #endregion

    }
}
