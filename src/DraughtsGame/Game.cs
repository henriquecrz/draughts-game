using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game.Draughts
{
    class Game
    {


        public List<Match> Matches { get; set; }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }
    }
}
