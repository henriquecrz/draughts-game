using System;
using DraughtsGame.UserInterface;

namespace DraughtsGame
{
    public class Program // Public?
    {
        static void Main() // string[] args
        {
            SetConsoleConfiguration();
            StartupMenu.Show();
        }

        private static void SetConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
