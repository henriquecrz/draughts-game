using System;

namespace DraughtsGame
{
    public class Program
    {
        static void Main() // string[] args
        {
            SetConsoleConfiguration();
            Menu.Show();
        }

        private static void SetConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
