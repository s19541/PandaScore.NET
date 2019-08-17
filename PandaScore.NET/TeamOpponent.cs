using Newtonsoft.Json;
using PandaScoreNET.LoL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET
{
    public class TeamOpponent
    {
        [JsonProperty("opponent")]
        public MatchParticipantTeam Team { get; private set; }
        public OpponentType Type => OpponentType.team;
    }
}
