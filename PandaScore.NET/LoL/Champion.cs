using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PandaScore.NET.LoL
{
    public class Champion
    {
        #region Properties
        [JsonProperty("armor")]
        public float Armor { get; private set; }
        [JsonProperty("armorperlevel")]
        public float ArmorPerLevel { get; private set; }
        [JsonProperty("attackdamage")]
        public float AttackDamage { get; private set; }
        [JsonProperty("attackdamageperlevel")]
        public float AttackDamagePerLevel { get; private set; }
        [JsonProperty("attackrange")]
        public float AttackRange { get; private set; }
        [JsonProperty("attackspeedoffset")]
        public float? AttackSpeedOffset { get; private set; }
        [JsonProperty("attackspeedperlevel")]
        public float AttackSpeedPerLevel { get; private set; }
        [JsonProperty("big_image_url")]
        public string BigImageUrl { get; private set; }
        [JsonProperty("crit")]
        public float Crit { get; private set; }
        [JsonProperty("critperlevel")]
        public float CritPerLevel { get; private set; }
        [JsonProperty("hp")]
        public float Hp { get; private set; }
        [JsonProperty("hpperlevel")]
        public float HpPerLevel { get; private set; }
        [JsonProperty("hpregen")]
        public float HpRegen { get; private set; }
        [JsonProperty("hpregenperlevel")]
        public float HpRegenPerLevel { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; }
        [JsonProperty("movespeed")]
        public float MoveSpeed { get; private set; }
        [JsonProperty("mp")]
        public float ManaPoints { get; }
        [JsonProperty("mpperlevel")]
        public float ManaPointsPerLevel { get; private set; }
        [JsonProperty("mpregen")]
        public float ManaRegen { get; private set; }
        [JsonProperty("mpregenperlevel")]
        public float ManaRegenPerLevel { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("spellblock")]
        public float MagicResist { get; private set; }
        [JsonProperty("spellblockperlevel")]
        public float MagicResistPerLevel { get; private set; }
        [JsonProperty("videogame_versions")]
        public string[] VideoGameVersions { get; private set; }
        #endregion

        #region Constructors
        public Champion() { }
        #endregion

        #region Equals_HashCode
        public override bool Equals(object obj)
        {
            var champion = obj as Champion;
            return champion != null &&
                   Id == champion.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        } 
        #endregion
    }
}
