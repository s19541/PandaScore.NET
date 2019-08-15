using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    /// <summary>
    /// Represents a block of matches inside a series, such as playoffs or regular season, or a specific tournament.
    /// </summary>
    public class Tournament
    {
        #region Properties
        [JsonProperty("begin_at")]
        public DateTime BeginAt { get; private set; }
        [JsonProperty("end_at")]
        public DateTime? EndAt { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("league")]
        public League League { get; private set; }
        [JsonProperty("league_id")]
        public int LeagueId { get; private set; }
        [JsonProperty("matches")]
        public Match[] Matches { get; private set; }
        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("serie")]
        public Series Series { get; private set; }
        [JsonProperty("serie_id")]
        public int SeriesId { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        [JsonProperty("teams")]
        public Team[] Teams { get; private set; }
        [JsonProperty("videogame")]
        public VideoGame VideoGame { get; private set; }
        [JsonProperty("winner_id")]
        public int WinnerId { get; private set; }
        [JsonProperty("winner_type")]
        public string WinnerType { get; private set; }
        #endregion

        #region Equals_HashCode
        public override bool Equals(object obj)
        {
            var tournament = obj as Tournament;
            return tournament != null &&
                   Id == tournament.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
        #endregion
    }
}
