using System;
using System.Collections.Generic;

namespace draughts_game.Game
{
    class Match
    {
        public Match()
        {
            Players = new List<Player>();
            Board = new Piece[Constant.BOARD_SIZE, Constant.BOARD_SIZE];
        }

        public List<Player> Players { get; private set; }

        public Piece[,] Board { get; private set; }

        public void Start()
        {
            if (Players.Count < Constant.MIN_NUMBER_OF_PLAYERS)
            {
                Console.WriteLine(Constant.CREATE_PLAYERS_MESSAGE);

                CreatePlayers();
            }

            int playerIndex = new Random().Next(Players.Count);

            while (GetWinner() != null)
            {
                Player player = Players[playerIndex];

                DisplayTable();
                Console.WriteLine($"Player {player.Name}, it's your turn.");

                Coordinate pieceCoordinate;
                Coordinate destination;
                Response response;

                do
                {
                    Console.Write("Select a piece to move: ");

                    pieceCoordinate = new Coordinate(Console.ReadLine());
                    response = IsPieceValid(pieceCoordinate);

                    if (!response.Success)
                    {
                        Console.Clear();
                        Console.WriteLine(response.Message);
                    }
                } while (!response.Success);

                do
                {
                    Console.Write("Now choose a destination: ");

                    destination = new Coordinate(Console.ReadLine());
                    response = IsDestinationValid(destination);

                    if (!response.Success)
                    {
                        Console.Clear();
                        Console.WriteLine(response.Message);
                    }
                } while (!response.Success);

                Move(pieceCoordinate, destination);
                ChangeTurn(ref playerIndex);
            }

            Player winner = GetWinner();

            Console.WriteLine($"Congratulations, {winner.Name}, you won with {winner.Pieces} piece(s) ahead!");
        }

        private void CreatePlayers()
        {
            while (Players.Count < Constant.MIN_NUMBER_OF_PLAYERS)
            {
                Console.Write(Constant.NAME_INPUT_LABEL);

                string name = Console.ReadLine();

                if (IsNameValid(name))
                {
                    Players.Add(new Player(name));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(Constant.EXISTING_USER_ERROR_MESSAGE + Environment.NewLine);
                }
            }
        }

        private bool IsNameValid(string name)
        {
            return !Players.Exists(player => player.Name == name);
        }

        private Response IsPieceValid(Coordinate coordinate)
        {
            bool success = false;
            string message = string.Empty;

            return new Response(success, message);
        }

        private Response IsDestinationValid(Coordinate coordinate)
        {
            bool success = false;
            string message = string.Empty;

            return new Response(success, message);
        }

        private void ChangeTurn(ref int index)
        {
            index += 1;
            index %= Players.Count;
        }

        private void DisplayTable()
        {
            int rowLength = Board.GetLength(0);
            int columnLength = Board.GetLength(1);
            int displayRowLength = (rowLength * 4) - 1;
            string board = "";

            board += GetLine(displayRowLength);

            for (int row = 0; row < rowLength; row++)
            {
                board += Environment.NewLine + "|";

                for (int column = 0; column < columnLength; column++)
                {
                    board += " " + Board[row, column] + " |";
                }

                board += Environment.NewLine + GetLine(displayRowLength);
            }

            Console.Clear();
            Console.WriteLine(board);
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

        private void Move(Coordinate from, Coordinate to)
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

        private Player GetWinner()
        {
            return new Player("a");
        }
    }
}
