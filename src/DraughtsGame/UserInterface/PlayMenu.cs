using System;

namespace DraughtsGame.UserInterface
{
    public static class PlayMenu
    {
        private static bool _quit = false;

        public static void Show()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("#==========================#");
                Console.WriteLine("#                          #");
                Console.WriteLine("#==========================#");
                Console.WriteLine();
                Console.WriteLine("Type \"Play\" or \"Quit\".");
                Console.Write(">> What would you like to do? ");

                var command = Console.ReadLine().Trim().ToLower();

                CommandRoute(command);
            } while (!_quit);

            Console.WriteLine("See you soon!");
            Console.Read();
        }

        private static void CommandRoute(string command)
        {
            // switch (true)
            // {

            // }
        }
    }
}
