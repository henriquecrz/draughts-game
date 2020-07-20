using System;

namespace DraughtsGame.UserInterface
{
    public static class Menu
    {
        private static bool _quit = false;

        public static void Show()
        {
            Console.WriteLine("#==========================#");
            Console.WriteLine("# Henrique's Draughts Game #");
            Console.WriteLine("#==========================#");

            while (!_quit)
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
            else if (command.StartsWith("quit"))
            {
                _quit = true;
            }
            else
            {

            }
        }
    }
}
