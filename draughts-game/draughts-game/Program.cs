using draughts_game.Game;
using System;
using System.Drawing;
using System.Linq;

namespace draughts_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Draughts draughts = new Draughts();

            // draughts.Play();

            string[,] example = new string[8, 8] {
                { " ", "x", " ", "x", " ", "x", " ", "x" },
                { "x", " ", "x", " ", "x", " ", "x", " " },
                { " ", "x", " ", "x", " ", "x", " ", "x" },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { "o", " ", "o", " ", "o", " ", "o", " " },
                { " ", "o", " ", "o", " ", "o", " ", "o" },
                { "o", " ", "o", " ", "o", " ", "o", " " }
            };

            draughts.DisplayTable(example);

            Console.ReadKey();
        }
    }
}
