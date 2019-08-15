using PandaScoreNET.LoL.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    public class TournamentQueryOptions : QueryConfiguration
    {
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<DateTime> BeginAt { get; } = new QueryOption<DateTime>("begin_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<DateTime> EndAt { get; } = new QueryOption<DateTime>("end_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> LeagueId { get; } = new QueryOption<int>("league_id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<DateTime> ModifiedAt { get; } = new QueryOption<DateTime>("modified_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> SeriesId { get; } = new QueryOption<int>("serie_id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Slug { get; } = new QueryOption<string>("slug", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> WinnerId { get; } = new QueryOption<int>("winner_id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> WinnerType { get; } = new QueryOption<string>("winner_type", QueryOptionType.All);
    }
}
