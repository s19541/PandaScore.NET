using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PandaScoreNET.LoL.QueryOptions
{
    public abstract class QueryConfiguration
    {
        protected List<QueryOption> properties = new List<QueryOption>();
        protected List<string> sortStringOrder = new List<string>();

        protected QueryConfiguration()
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (var prop in props)
            {
                QueryOption option = prop.GetValue(this) as QueryOption;
                properties.Add(option);
                option.SortChanged += SortChangedHandler;
            }
        }
        
        protected void SortChangedHandler(QueryOption option, bool added)
        {
            if (added && sortStringOrder.Contains(option.ToSortString()) == false)
            {
                sortStringOrder.Add(option.ToSortString());
            }
            else if (!added && sortStringOrder.Contains(option.ToSortString()))
            {
                sortStringOrder.Remove(option.ToSortString());
            }
        }

        /// <summary>
        /// Gets the query string portion of a request.
        /// </summary>
        /// <returns>Query string, formatted as required by the PandaScore API.</returns>
        internal virtual string GetQueryString()
        {
            var groups = properties.GroupBy(x => x.CurrentType);
            string filterString = null, searchString = null, rangeString = null, sortString = null;
            foreach (var group in groups)
            {
                if (group.Key == QueryOptionType.None)
                {
                    continue;
                }
                if ((group.Key & QueryOptionType.Filter) == QueryOptionType.Filter)
                {
                    filterString = string.Join("&", group.Select(x => x.ToFilterString()));
                }
                if ((group.Key & QueryOptionType.Search) == QueryOptionType.Search)
                {
                    searchString = string.Join("&", group.Select(x => x.ToSearchString()));
                }
                if ((group.Key & QueryOptionType.Range) == QueryOptionType.Range)
                {
                    rangeString = string.Join("&", group.Select(x => x.ToRangeString()));
                }
            }
            //has to be done separately to keep sort ordering
            sortString = sortStringOrder.Count > 0 ? "sort=" + string.Join(",", sortStringOrder) : "";
            return string.Join("&", filterString, searchString, rangeString, sortString);
        }
    }
}
