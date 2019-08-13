using PandaScore.NET.LoL.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class RuneQueryOptions : QueryConfiguration
    {
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
    }
}
