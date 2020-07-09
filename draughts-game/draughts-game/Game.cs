using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game
{
    class Game
    {
        public Game(Configuration config)
        {
            SetConsoleConfiguration();
            CreatePlayers();

            Board = new Piece[config.BoardSize, config.BoardSize];
        }

        private void SetConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.OutputEncoding = Encoding.Unicode;
            //Console.WriteLine("\x263A");
        }

        private void CreatePlayers()
        {
            Players = new List<Player>();

            for (int i = 0; i < Constant.MAX_NUMBER_OF_PLAYERS; i += 1)
            {
                Console.Write(Constant.NAME_INPUT_LABEL);

                string name = Console.ReadLine();

                if (Players.Exists(player => player.Name != name))
                {
                    Players.Add(new Player(name));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Já existe um jogador com esse nome de usuário. Tente outro nome.\n");
                }
            }
        }

        public List<Player> Players { get; private set; }

        public Player Player1 { get; set; }

        public Piece[,] Board { get; private set; }


        public void PlayGame()
        {
            Random rand = new Random();
            int playerIndex = rand.Next(Constant.MAX_NUMBER_OF_PLAYERS);
            Player player = Players[playerIndex];

            do
            {
                Console.WriteLine($"Player (), it's your turn.");
                Coordinate destination = new Coordinate(Console.ReadLine());



            } while (true);
        }

        public void DisplayTable(int[,] array)
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

        private string GetLine(int lineLength)
        {
            string line = "+";

            for (int i = 1; i <= lineLength; i++)
            {
                line += (i % 4 == 0) ? "+" : "-";
            }

            return line += "+";
        }

        private bool IsValidMove(Coordinate from, Coordinate to)
        {
            Piece piece = Board[from.X, from.Y];



            return true;
        }

        public void Move(Coordinate from, Coordinate to)
        {
            if (IsValidMove(from, to))
            {
                Board[from.X, from.Y] = Board[to.X, to.Y];
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
