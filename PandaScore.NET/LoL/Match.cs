using Newtonsoft.Json;
using PandaScore.NET;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    /// <summary>
    /// Represents a specific match, such as a regular season Bo1, or a playoff match.
    /// </summary>
    public class Match
    {
        #region Properties
        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; private set; }
        [JsonProperty("end_at")]
        public DateTime? EndAt { get; private set; }
        [JsonProperty("draw")]
        public bool Draw { get; private set; }
        [JsonProperty("forfeit")]
        public bool Forfeit { get; private set; }
        [JsonProperty("games")]
        public Game[] Games { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("league")]
        public League League { get; private set; }
        [JsonProperty("league_id")]
        public int LeagueId { get; private set; }
        [JsonProperty("live")]
        public LiveData LiveData { get; private set; }
        [JsonProperty("live_url")]
        public string LiveUrl { get; private set; }
        [JsonProperty("match_type")]
        public string MatchType { get; private set; }
        [JsonProperty("modified_at")]
        public DateTime? ModifiedAt { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("number_of_games")]
        public int NumberOfGames { get; private set; }
        [JsonProperty("opponents")]
        public TeamOpponent[] Opponents { get; private set; }
        [JsonProperty("results")]
        public MatchResults[] Results { get; private set; }
        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; private set; }
        [JsonProperty("serie")]
        public Series Series { get; private set; }
        [JsonProperty("series_id")]
        public int SeriesId { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        [JsonProperty("status")]
        public MatchStatus Status { get; private set; }
        [JsonProperty("tournament")]
        public Tournament Tournament { get; private set; }
        [JsonProperty("tournament_id")]
        public int TournamentId { get; private set; }
        [JsonProperty("videogame")]
        public VideoGame VideoGame { get; private set; }
        [JsonProperty("videogame_version")]
        public VideoGameVersion VideoGameVersion { get; private set; }
        [JsonProperty("winner")]
        public Winner Winner { get; private set; }
        [JsonProperty("winner_id")]
        public int? WinnerId { get; private set; }

        #endregion
    }
}
