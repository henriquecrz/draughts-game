using System;

namespace draughts_game.Game
{
    class Menu
    {
        public static bool Quit = false;

        public static void Show()
        {
            Console.WriteLine("#==========================#");
            Console.WriteLine("# Henrique's Draughts Game #");
            Console.WriteLine("#==========================#");

            while (!Quit)
            {
                Console.WriteLine();
                Console.WriteLine("Type \"Play\" or \"Quit\".");
                Console.Write(">> What would you like to do? ");

                var command = Console.ReadLine().Trim().ToLower();

                CommandRoute(command);
            }

            Console.WriteLine("See you soon!");
            Console.Read();
        }

        private static void CommandRoute(string command)
        {
            if (command.StartsWith("play"))
            {
                Match match = new Match();

                match.Start();
            }
        }
    }
}
