using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class Series
    {
        #region Properties
        [JsonProperty("begin_at")]
        public DateTime BeginAt { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("end_at")]
        public DateTime EndAt { get; private set; }
        [JsonProperty("full_name")]
        public string FullName { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("league")]
        public League League { get; private set; }
        [JsonProperty("league_id")]
        public int LeagueId { get; private set; }
        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("prizepool")]
        public int? Prizepool { get; private set; }
        [JsonProperty("season")]
        public string Season { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        [JsonProperty("tournaments")]
        public Tournament[] Tournaments { get; private set; }
        [JsonProperty("winner_id")]
        public int? WinnerId { get; private set; }
        [JsonProperty("winner_type")]
        public string WinnerType { get; private set; }
        [JsonProperty("year")]
        public int Year { get; private set; }
        #endregion
    }
}
