using PandaScoreNET.LoL.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    public class ItemQueryOptions : QueryConfiguration
    {
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatArmor { get; } = new QueryOption<float>("flat_armor_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatCritChance { get; } = new QueryOption<float>("flat_crit_change_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatHp { get; } = new QueryOption<float>("flat_hp_pool_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatHpRegen { get; } = new QueryOption<float>("flat_hp_regen_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatAbilityPower { get; } = new QueryOption<float>("flat_magic_damage_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatMovementSpeed { get; } = new QueryOption<float>("flat_movement_speed_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatMana { get; } = new QueryOption<float>("flat_mp_pool_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatManaRegen { get; } = new QueryOption<float>("flat_mp_regen_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatAttackDamage { get; } = new QueryOption<float>("flat_physical_damage_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> FlatMagicResist { get; } = new QueryOption<float>("flat_spell_block_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> GoldBase { get; } = new QueryOption<float>("gold_base", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<bool> Purchasable { get; } = new QueryOption<bool>("gold_purchasable", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> SellValue { get; } = new QueryOption<float>("gold_sell", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> TotalGold { get; } = new QueryOption<float>("gold_total", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<int> Id { get; private set; } = new QueryOption<int>("id", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> ImageUrl { get; private set; } = new QueryOption<string>("image_url", QueryOptionType.All);
        /// <summary>Can be used to filter, sort and range. </summary>
        public QueryOption<bool> IsTrinket { get; private set; } = new QueryOption<bool>("trinket", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, range, or as a search term. </summary>
        public QueryOption<string> Name { get; private set; } = new QueryOption<string>("name", QueryOptionType.All);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> PercentAttackSpeed { get; private set; } = new QueryOption<float>("percent_attack_speed_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> PercentLifesteal { get; private set; } = new QueryOption<float>("percent_life_steal_mod", QueryOptionType.FilterRangeSort);
        /// <summary>Can be used to filter, sort, and range. </summary>
        public QueryOption<float> PercentMovementSpeed { get; private set; } = new QueryOption<float>("percent_movement_speed_mod", QueryOptionType.FilterRangeSort);
    }
}
