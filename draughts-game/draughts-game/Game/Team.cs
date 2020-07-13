using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game.Game
{
    class Team
    {
        public Team()
        {

        }

        public string Tag { get; set; }

        public List<Player> Players { get; private set; }
    }
}
