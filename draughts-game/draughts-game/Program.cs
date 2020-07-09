using System;
using System.Drawing;
using System.Linq;

namespace draughts_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            Game game = new Game(config);

            //game.PlayGame();

            int[,] example = new int[8, 8] {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            game.DisplayTable(example);

            Console.ReadKey();
        }
    }
}
