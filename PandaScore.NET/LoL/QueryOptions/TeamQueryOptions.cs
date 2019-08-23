using PandaScoreNET.LoL.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    /// <summary>
    /// Represents settings required to make a team query. Refer to each property's comments for usage.
    /// </summary>
    public class TeamQueryOptions : QueryConfiguration
    {
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Acronym { get; } = new QueryOption<string>("acronym", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> ImageUrl { get; } = new QueryOption<string>("image_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Slug { get; } = new QueryOption<string>("slug", QueryOptionType.All);
    }
}
