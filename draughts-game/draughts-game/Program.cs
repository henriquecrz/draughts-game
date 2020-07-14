using draughts_game.Game;
using System;

namespace draughts_game
{
    class Program
    {
        static void Main() // string[] args
        {
            SetConsoleConfiguration();
            Menu.Show();

            //string[,] example = new string[8, 8] {
            //    { " ", "x", " ", "x", " ", "x", " ", "x" },
            //    { "x", " ", "x", " ", "x", " ", "x", " " },
            //    { " ", "x", " ", "x", " ", "x", " ", "x" },
            //    { " ", " ", " ", " ", " ", " ", " ", " " },
            //    { " ", " ", " ", " ", " ", " ", " ", " " },
            //    { "o", " ", "o", " ", "o", " ", "o", " " },
            //    { " ", "o", " ", "o", " ", "o", " ", "o" },
            //    { "o", " ", "o", " ", "o", " ", "o", " " }
            //};

            Console.Read();
        }

        private static void SetConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
