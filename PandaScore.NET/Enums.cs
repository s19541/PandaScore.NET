﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PandaScoreNET
{
    public enum OpponentType { player, team }
    public enum MatchStatus { canceled, finished, not_started, running, postponed }
    public enum MatchType { best_of, custom, ow_best_of }
}
