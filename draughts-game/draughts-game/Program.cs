using System;
using System.Linq;

namespace draughts_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[8, 8] {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            DisplayTable(array);

            Console.ReadKey();
        }

        static void DisplayTable(int[,] array)
        {
            int rowLength = array.GetLength(0);
            int columnLength = array.GetLength(1);
            int displayRowLength = (rowLength * 4) - 1;
            string a = "";

            a += GetLine(displayRowLength);

            for (int row = 0; row < rowLength; row++)
            {
                a += Environment.NewLine + "|";

                for (int column = 0; column < columnLength; column++)
                {
                    a += " " + array[row, column] + " |";
                }

                a += Environment.NewLine + GetLine(displayRowLength);
            }

            Console.WriteLine(a);
        }

        static string GetLine(int lineLength)
        {
            string line = "+";

            for (int i = 1; i <= lineLength; i++)
            {   
                line += (i % 4 == 0) ? "+" : "-";
            }

            return line += "+";
        }

        static void Move()
        {

        }

        static void Swap()
        {

        }
    }
}
