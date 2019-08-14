using PandaScore.NET.LoL.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class MatchQueryOptions : QueryConfiguration
    {
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<bool> Draw { get; } = new QueryOption<bool>("draw", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<bool> Forfeit { get; } = new QueryOption<bool>("forfeit", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter.</summary>
        public QueryOption<bool> Finished { get; } = new QueryOption<bool>("finished", QueryOptionType.Filter);
        /// <summary>Can be used to filter.</summary>
        public QueryOption<bool> Future { get; } = new QueryOption<bool>("future", QueryOptionType.Filter);
        /// <summary>Can be used to filter.</summary>
        public QueryOption<bool> NotStarted { get; } = new QueryOption<bool>("not_started", QueryOptionType.Filter);
        /// <summary>Can be used to filter.</summary>
        public QueryOption<bool> Past { get; } = new QueryOption<bool>("past", QueryOptionType.Filter);
        /// <summary>Can be used to filter.</summary>
        public QueryOption<bool> Running { get; } = new QueryOption<bool>("running", QueryOptionType.Filter);
        /// <summary>Can be used to filter.</summary>
        public QueryOption<bool> Unscheduled { get; } = new QueryOption<bool>("unscheduled", QueryOptionType.Filter);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<DateTime> BeginAt { get; } = new QueryOption<DateTime>("begin_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<DateTime> EndAt { get; } = new QueryOption<DateTime>("end_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<DateTime> ModifiedAt { get; } = new QueryOption<DateTime>("modified_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<DateTime> ScheduledAt { get; } = new QueryOption<DateTime>("scheduled_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<int> LeagueId { get; } = new QueryOption<int>("league_id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> LiveUrl { get; } = new QueryOption<string>("live_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> MatchType { get; } = new QueryOption<string>("match_type", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<int> NumberOfGames { get; } = new QueryOption<int>("number_of_games", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<int> SeriesId { get; } = new QueryOption<int>("serie_id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Slug { get; } = new QueryOption<string>("slug", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Status { get; } = new QueryOption<string>("status", QueryOptionType.All);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<int> TournamentId { get; } = new QueryOption<int>("tournament_id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<int> WinnerId { get; } = new QueryOption<int>("winner_id", QueryOptionType.FilterRangeSort);
    }
}
