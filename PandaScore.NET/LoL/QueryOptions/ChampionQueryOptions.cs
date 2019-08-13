using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class ChampionQueryOptions
    {

        #region Properties
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> Armor { get; } = new QueryOption<float>("armor", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ArmorPerLevel { get; } = new QueryOption<float>("armorperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackDamage { get; } = new QueryOption<float>("attackdamage", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackDamagePerLevel { get; } = new QueryOption<float>("attackdamageperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackRange { get; } = new QueryOption<float>("attackrange", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackSpeedOffset { get; } = new QueryOption<float>("attackspeedoffset", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackSpeedPerLevel { get; } = new QueryOption<float>("attackspeedperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>A URL pointing to the champion's image. Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> BigImageUrl { get; } = new QueryOption<string>("big_image_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> Crit { get; } = new QueryOption<float>("crit", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> CritPerLevel { get; } = new QueryOption<float>("critperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> Hp { get; } = new QueryOption<float>("hp", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> HpPerLevel { get; } = new QueryOption<float>("hpperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> HpRegen { get; } = new QueryOption<float>("hpregen", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> HpRegenPerLevel { get; } = new QueryOption<float>("hpregenperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangehSort);
        /// <summary>A URL pointing the champion's image. Can be used to filter, sort, range, or as a seach term. </summary>
        public QueryOption<string> ImageUrl { get; } = new QueryOption<string>("image_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> MoveSpeed { get; } = new QueryOption<float>("movespeed", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaPoints { get; } = new QueryOption<float>("mp", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaPointsPerLevel { get; } = new QueryOption<float>("mpperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaRegen { get; } = new QueryOption<float>("mpregen", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaRegenPerLevel { get; } = new QueryOption<float>("mpregenperlevel", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> MagicResist { get; } = new QueryOption<float>("spellblock", QueryOptionType.FilterRangehSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> MagicResistPerLevel { get; } = new QueryOption<float>("spellblockperlevel", QueryOptionType.FilterRangehSort);
        #endregion

        List<QueryOption> properties = new List<QueryOption>();
        List<string> sortStringOrder = new List<string>();

        public ChampionQueryOptions()
        {
            PropertyInfo[] props = typeof(ChampionQueryOptions).GetProperties();
            foreach (var prop in props)
            {
                QueryOption option = prop.GetValue(this) as QueryOption;
                properties.Add(option);
                option.SortChanged += SortChangedHandler;
            }
        }

        private void SortChangedHandler(QueryOption option, bool added)
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
        internal string GetQueryString()
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
            sortString = "sort=" + string.Join(",", sortStringOrder);
            return string.Join("&", filterString, searchString, rangeString, sortString);
        }
    }
}
