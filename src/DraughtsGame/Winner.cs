﻿using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game.Draughts
{
    class Winner : Player
    {
        public Winner(string name, char character, int numberPieces) : base(name, character)
        {
            NumberPieces = numberPieces;
        }

        public int NumberPieces { get; }
    }
}