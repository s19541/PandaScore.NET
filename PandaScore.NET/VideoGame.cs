﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScore.NET
{
    public struct VideoGame
    {
        [JsonProperty("current_version")]
        public string CurrentVersion { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("slug")]
        public string Slug { get; private set; }

        public override bool Equals(object obj)
        {
            if (!(obj is VideoGame))
            {
                return false;
            }

            var game = (VideoGame)obj;
            return Id == game.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
