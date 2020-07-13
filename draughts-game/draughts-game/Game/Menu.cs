using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game.Game
{
    class Menu
    {
        public void Show()
        {
            Console.WriteLine(Header());

        }

        public string Header()
        {
            return "===================\n   Draughts Game   \n===================";
        }
    }
}
