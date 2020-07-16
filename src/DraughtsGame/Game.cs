using System;
using System.Collections.Generic;

namespace DraughtsGame
{
    public static class Game
    {


        public static List<Match> Matches { get; set; }

        public static void AddMatch(Match match)
        {
            Matches.Add(match);
        }
    }
}
