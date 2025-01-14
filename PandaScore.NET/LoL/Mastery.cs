﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET.LoL
{
    public class Mastery
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            var masteries = obj as Mastery;
            return masteries != null &&
                   Id == masteries.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
