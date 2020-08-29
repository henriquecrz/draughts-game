using System;
using System.Text;
using System.Threading;
using DraughtsGame.UserInterface;

namespace DraughtsGame
{
    public class Program
    {
        static void Main()
        {
            SetConsoleConfiguration();
            // StartupMenu.Show();

            //int cont = 0; control flow by a counter
            //Console.ReadLine() catch ConsoleKey.Escape

            // do
            // {
            //     System.Console.Write("Label: ");
            //     var a = Console.ReadLine();
            // } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            // do
            // {
            //     if (!Console.KeyAvailable)
            //     {
            //         System.Console.Write("Label: ");
            //         string a = Console.ReadLine();
            //     }

            //     Console.WriteLine("Passou");
            //     break;
            // } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            // System.Console.WriteLine("Deu certo");

            Console.Clear();
            Console.Write("Enter your name and press ENTER.  (ESC to cancel): ");
            string name = readLineWithCancel();

            Console.WriteLine("\r\n{0}", name == null ? "Cancelled" : name);

            Console.ReadLine();
        }

        //Returns null if ESC key pressed during input.
        private static string readLineWithCancel()
        {
            string result = null;

            StringBuilder buffer = new StringBuilder();

            //The key is read passing true for the intercept argument to prevent
            //any characters from displaying when the Escape key is pressed.
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
            {
                Console.Write(info.KeyChar);
                buffer.Append(info.KeyChar);
                info = Console.ReadKey(true);
            }

            if (info.Key == ConsoleKey.Enter)
            {
                result = buffer.ToString();
            }

            return result;
        }

        private static void SetConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CancelKeyPress += (sender, args) =>
            {
                Util.Exit();
            };
        }
    }
}
