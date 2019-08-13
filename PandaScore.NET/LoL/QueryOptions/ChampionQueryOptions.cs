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
    public class ChampionQueryOptions : QueryConfiguration
    {

        #region Properties
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> Armor { get; } = new QueryOption<float>("armor", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ArmorPerLevel { get; } = new QueryOption<float>("armorperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackDamage { get; } = new QueryOption<float>("attackdamage", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackDamagePerLevel { get; } = new QueryOption<float>("attackdamageperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackRange { get; } = new QueryOption<float>("attackrange", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackSpeedOffset { get; } = new QueryOption<float>("attackspeedoffset", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> AttackSpeedPerLevel { get; } = new QueryOption<float>("attackspeedperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>A URL pointing to the champion's image. Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> BigImageUrl { get; } = new QueryOption<string>("big_image_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> Crit { get; } = new QueryOption<float>("crit", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> CritPerLevel { get; } = new QueryOption<float>("critperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> Hp { get; } = new QueryOption<float>("hp", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> HpPerLevel { get; } = new QueryOption<float>("hpperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> HpRegen { get; } = new QueryOption<float>("hpregen", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> HpRegenPerLevel { get; } = new QueryOption<float>("hpregenperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> Id { get; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        /// <summary>A URL pointing the champion's image. Can be used to filter, sort, range, or as a seach term. </summary>
        public QueryOption<string> ImageUrl { get; } = new QueryOption<string>("image_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> MoveSpeed { get; } = new QueryOption<float>("movespeed", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaPoints { get; } = new QueryOption<float>("mp", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaPointsPerLevel { get; } = new QueryOption<float>("mpperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaRegen { get; } = new QueryOption<float>("mpregen", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> ManaRegenPerLevel { get; } = new QueryOption<float>("mpregenperlevel", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Name { get; } = new QueryOption<string>("name", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> MagicResist { get; } = new QueryOption<float>("spellblock", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> MagicResistPerLevel { get; } = new QueryOption<float>("spellblockperlevel", QueryOptionType.FilterRangeSort);
        #endregion
    }
}
