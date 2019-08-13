using PandaScore.NET.LoL.QueryOptions;
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
        public QueryOption<float> Armor { get; } = new QueryOption<float>("armor", QueryOptionType.All);
        public QueryOption<float> ArmorPerLevel { get; } = new QueryOption<float>("armorperlevel", QueryOptionType.All);
        public QueryOption<float> AttackDamage { get; } = new QueryOption<float>("attackdamage", QueryOptionType.All);
        public QueryOption<float> AttackDamagePerLevel { get; } = new QueryOption<float>("attackdamageperlevel", QueryOptionType.All);
        public QueryOption<float> AttackRange { get; } = new QueryOption<float>("attackrange", QueryOptionType.All);
        public QueryOption<float> AttackSpeedOffset { get; } = new QueryOption<float>("attackspeedoffset", QueryOptionType.All);
        public QueryOption<float> AttackSpeedPerLevel { get; } = new QueryOption<float>("attackspeedperlevel", QueryOptionType.All);
        public QueryOption<string> BigImageUrl { get; } = new QueryOption<string>("big_image_url", QueryOptionType.All);
        public QueryOption<float> Crit { get; } = new QueryOption<float>("crit", QueryOptionType.All);
        public QueryOption<float> CritPerLevel { get; } = new QueryOption<float>("critperlevel", QueryOptionType.All);
        public QueryOption<float> Hp { get; } = new QueryOption<float>("hp", QueryOptionType.All);
        public QueryOption<float> HpPerLevel { get; } = new QueryOption<float>("hpperlevel", QueryOptionType.All);
        public QueryOption<float> HpRegen { get; } = new QueryOption<float>("hpregen", QueryOptionType.All);
        public QueryOption<float> HpRegenPerLevel { get; } = new QueryOption<float>("hpregenperlevel", QueryOptionType.All);
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.All);
        public QueryOption<string> ImageUrl { get; } = new QueryOption<string>("image_url", QueryOptionType.All);
        public QueryOption<float> MoveSpeed { get; } = new QueryOption<float>("movespeed", QueryOptionType.All);
        public QueryOption<float> ManaPoints { get; } = new QueryOption<float>("mp", QueryOptionType.All);
        public QueryOption<float> ManaPointsPerLevel { get; } = new QueryOption<float>("mpperlevel", QueryOptionType.All);
        public QueryOption<float> ManaRegen { get; } = new QueryOption<float>("mpregen", QueryOptionType.All);
        public QueryOption<float> ManaRegenPerLevel { get; } = new QueryOption<float>("mpregenperlevel", QueryOptionType.All);
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        public QueryOption<float> MagicResist { get; } = new QueryOption<float>("spellblock", QueryOptionType.All);
        public QueryOption<float> MagicResistPerLevel { get; } = new QueryOption<float>("spellblockperlevel", QueryOptionType.All);
        #endregion

        List<QueryOption> properties = new List<QueryOption>();

        public ChampionQueryOptions()
        {
            PropertyInfo[] props = typeof(ChampionQueryOptions).GetProperties();
            foreach (var prop in props)
            {
                properties.Add(prop.GetValue(this) as QueryOption);
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
                if ((group.Key & QueryOptionType.Sort) == QueryOptionType.Sort)
                {
                    sortString = "sort=" + string.Join(",", group.Select(x => x.ToSortString()));
                }
            }
            return string.Join("&", filterString, searchString, rangeString, sortString);
        }
    }
}
