using System;
using DraughtsGame.UserInterface;

namespace DraughtsGame
{
    public class Program
    {
        public static void Main()
        {
            SetConsoleConfiguration();
            StartupMenu.Show();
            ResetConsoleConfiguration();
        }

        private static void SetConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void ResetConsoleConfiguration()
        {
            Console.ResetColor();
        }
    }
}
