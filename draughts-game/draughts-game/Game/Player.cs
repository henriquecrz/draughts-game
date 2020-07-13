using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game.Game
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
            Pieces = Constant.NUMBER_OF_PIECES;
        }

        public string Name { get; private set; }

        public int Pieces { get; }
    }
}
