using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace draughts_game.Game
{
    class Draughts
    {
        public Draughts()
        {
            SetConsoleConfiguration();
            //CreatePlayers();
            CreateBoard();
        }

        private void SetConsoleConfiguration()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private void CreatePlayers()
        {
            Players = new List<Player>();

            for (int i = 0; i < Players.Count;) // Array.Exists(Players, n => n is null)
            {
                Console.Write(Constant.NAME_INPUT_LABEL);

                string name = Console.ReadLine();

                if (!Players.Exists(player => player.Name == name))
                {
                    Players[i] = new Player(name);
                    i++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(Constant.EXISTING_USER_ERROR_MESSAGE + Environment.NewLine);
                }
            }
        }

        private void CreateBoard()
        {
            Board = new Piece[Constant.BOARD_SIZE, Constant.BOARD_SIZE];


        }

        public List<Player> Players { get; private set; }

        public Piece[,] Board { get; private set; }

        public void Play()
        {
            Random rand = new Random();
            int playerIndex = rand.Next(Constant.MIN_NUMBER_OF_PLAYERS);
            Player player = Players[playerIndex];

            do
            {
                Console.WriteLine($"Player (), it's your turn.");
                Coordinate destination = new Coordinate(Console.ReadLine());


                ChangeTurn();
            } while (AnyPlayerHasAtLeastOnePiece());
        }

        private void ChangeTurn()
        {

        }

        private bool AnyPlayerHasAtLeastOnePiece()
        {
            return true;
        }

        public void DisplayTable(string[,] array)
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

        private bool IsValidMove(Coordinate from, Coordinate to)
        {
            Piece piece = Board[from.X, from.Y];

            if (Board[from.X, from.Y].Type == PieceType.Men)
            {

            }
            else
            {

            }

            return true;
        }
    }
}
