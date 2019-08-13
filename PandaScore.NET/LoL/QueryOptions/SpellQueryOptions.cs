using PandaScore.NET.LoL.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class SpellQueryOptions : QueryConfiguration
    {
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        public QueryOption<string> ImageUrl { get; } = new QueryOption<string>("image_url", QueryOptionType.All);
    }
}
