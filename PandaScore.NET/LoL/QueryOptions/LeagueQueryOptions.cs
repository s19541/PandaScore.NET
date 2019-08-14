using PandaScore.NET.LoL.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class LeagueQueryOptions : QueryConfiguration
    {
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> ImageUrl { get; } = new QueryOption<string>("image_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<bool> LiveSupported { get; } = new QueryOption<bool>("live_supported", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<DateTime> ModifiedAt { get; } = new QueryOption<DateTime>("modified_at", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Slug { get; } = new QueryOption<string>("slug", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Url { get; } = new QueryOption<string>("url", QueryOptionType.All);
    }
}
