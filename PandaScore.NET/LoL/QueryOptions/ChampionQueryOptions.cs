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
        public QueryOption<float> Armor { get; private set; } = new QueryOption<float>("armor", QueryOptionType.FilterAndRange);
        public QueryOption<float> ArmorPerLevel { get; private set; } = new QueryOption<float>("armorperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<float> AttackDamage { get; private set; } = new QueryOption<float>("attackdamage", QueryOptionType.FilterAndRange);
        public QueryOption<float> AttackDamagePerLevel { get; private set; } = new QueryOption<float>("attackdamageperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<float> AttackRange { get; private set; } = new QueryOption<float>("attackrange", QueryOptionType.FilterAndRange);
        public QueryOption<float> AttackSpeedOffset { get; private set; } = new QueryOption<float>("attackspeedoffset", QueryOptionType.FilterAndRange);
        public QueryOption<float> AttackSpeedPerLevel { get; private set; } = new QueryOption<float>("attackspeedperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<string> BigImageUrl { get; private set; } = new QueryOption<string>("big_image_url", QueryOptionType.FilterAndRange);
        public QueryOption<float> Crit { get; private set; } = new QueryOption<float>("crit", QueryOptionType.FilterAndRange);
        public QueryOption<float> CritPerLevel { get; private set; } = new QueryOption<float>("critperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<float> Hp { get; private set; } = new QueryOption<float>("hp", QueryOptionType.FilterAndRange);
        public QueryOption<float> HpPerLevel { get; private set; } = new QueryOption<float>("hpperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<float> HpRegen { get; private set; } = new QueryOption<float>("hpregen", QueryOptionType.FilterAndRange);
        public QueryOption<float> HpRegenPerLevel { get; private set; } = new QueryOption<float>("hpregenperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<int> Id { get; private set; } = new QueryOption<int>("id", QueryOptionType.FilterAndRange);
        public QueryOption<string> ImageUrl { get; private set; } = new QueryOption<string>("image_url", QueryOptionType.FilterAndRange);
        public QueryOption<float> MoveSpeed { get; private set; } = new QueryOption<float>("movespeed", QueryOptionType.FilterAndRange);
        public QueryOption<float> ManaPoints { get; private set; } = new QueryOption<float>("mp", QueryOptionType.FilterAndRange);
        public QueryOption<float> ManaPointsPerLevel { get; private set; } = new QueryOption<float>("mpperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<float> ManaRegen { get; private set; } = new QueryOption<float>("mpregen", QueryOptionType.FilterAndRange);
        public QueryOption<float> ManaRegenPerLevel { get; private set; } = new QueryOption<float>("mpregenperlevel", QueryOptionType.FilterAndRange);
        public QueryOption<string> Name { get; private set; } = new QueryOption<string>("name", QueryOptionType.FilterAndRange);
        public QueryOption<float> MagicResist { get; private set; } = new QueryOption<float>("spellblock", QueryOptionType.FilterAndRange);
        public QueryOption<float> MagicResistPerLevel { get; private set; } = new QueryOption<float>("spellblockperlevel", QueryOptionType.FilterAndRange);
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

        public string GetQueryString()
        {
            var applicable = properties.Where(x => x.HasFilterValue).Select(x => x).ToArray();
            var strings = applicable.Select(x => x.ToString()).ToArray();
            return string.Join("&", strings);
        }
    }
}
