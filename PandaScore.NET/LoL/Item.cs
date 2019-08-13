using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET.LoL
{
    public class Item
    {
        #region Properties
        [JsonProperty("flat_armor_mod")]
        public float? FlatArmor { get; private set; }
        [JsonProperty("flat_crit_chance_mod")]
        public float? FlatCritChance { get; private set; }
        [JsonProperty("flat_hp_pool_mod")]
        public float? FlatHp { get; private set; }
        [JsonProperty("flat_hp_regen_mod")]
        public float? FlatHpRegen { get; private set; }
        [JsonProperty("flat_magic_damage_mod")]
        public float? FlatAbilityPower { get; private set; }
        [JsonProperty("flat_movement_speed_mod")]
        public float? FlatMovementSpeed { get; private set; }
        [JsonProperty("flat_mp_pool_mod")]
        public float? FlatMana { get; private set; }
        [JsonProperty("flat_mp_regen_mod")]
        public float? FlatManaRegen { get; private set; }
        [JsonProperty("flat_physical_damage_mod")]
        public float? FlatAttackDamage { get; private set; }
        [JsonProperty("flat_spell_block_mod")]
        public float? FlatMagicResist { get; private set; }
        [JsonProperty("gold_base")]
        public float? GoldBase { get; private set; }
        [JsonProperty("gold_purchasable")]
        public bool Purchasable { get; private set; }
        [JsonProperty("gold_sell")]
        public float? SellValue { get; private set; }
        [JsonProperty("gold_total")]
        public float? TotalGold { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; }
        [JsonProperty("is_trinket")]
        public bool IsTrinket { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("percent_attack_speed_mod")]
        public float? PercentAttackSpeed { get; private set; }
        [JsonProperty("percent_life_steal_mod")]
        public float? PercentLifesteal { get; private set; }
        [JsonProperty("percent_movement_speed_mod")]
        public float? PercentMovementSpeed { get; private set; }
        [JsonProperty("videogame_versions")]
        public string[] VideogameVersions { get; private set; }
        #endregion

        #region Constructors
        public Item() { }
        #endregion

        #region Equals_HashCode
        public override bool Equals(object obj)
        {
            var item = obj as Item;
            return item != null &&
                   Id == item.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        } 
        #endregion
    }
}
