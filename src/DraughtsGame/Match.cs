using System;
using DraughtsGame.Constants;

namespace DraughtsGame
{
    public class Match
    {
        public Match()
        {
            DefinePlayerChar();
            CreateBoard();
        }

        private void DefinePlayerChar()
        {
            throw new NotImplementedException();
        }

        public static Player[] Players { get; private set; } // set? private?

        public Piece[,] Board { get; private set; } // set? private? Criar classe e chamar a propriedade de table

        public Winner Winner { get; private set; }

        private void CreateBoard()
        {
            Board = new Piece[Configuration.BOARD_SIZE, Configuration.BOARD_SIZE];

            Board[0, 1] = new Piece(Players[0].Character);
            Board[0, 3] = new Piece(Players[0].Character);
            Board[0, 5] = new Piece(Players[0].Character);
            Board[0, 7] = new Piece(Players[0].Character);
            Board[1, 0] = new Piece(Players[0].Character);
            Board[1, 2] = new Piece(Players[0].Character);
            Board[1, 4] = new Piece(Players[0].Character);
            Board[1, 6] = new Piece(Players[0].Character);
            Board[2, 1] = new Piece(Players[0].Character);
            Board[2, 3] = new Piece(Players[0].Character);
            Board[2, 5] = new Piece(Players[0].Character);
            Board[2, 7] = new Piece(Players[0].Character);

            Board[5, 0] = new Piece(Players[1].Character);
            Board[5, 2] = new Piece(Players[1].Character);
            Board[5, 4] = new Piece(Players[1].Character);
            Board[5, 6] = new Piece(Players[1].Character);
            Board[6, 1] = new Piece(Players[1].Character);
            Board[6, 3] = new Piece(Players[1].Character);
            Board[6, 5] = new Piece(Players[1].Character);
            Board[6, 7] = new Piece(Players[1].Character);
            Board[7, 0] = new Piece(Players[1].Character);
            Board[7, 2] = new Piece(Players[1].Character);
            Board[7, 4] = new Piece(Players[1].Character);
            Board[7, 6] = new Piece(Players[1].Character);

            //int rowLength = Board.GetLength(0);
            //int columnLength = Board.GetLength(1);

            //for (int row = 0; row < rowLength; row++)
            //{
            //    if (row == 3 || row == 4)
            //    {
            //        continue;
            //    }

            //    for (int column = 0; column < columnLength; column++)
            //    {
            //        if (true)
            //        {

            //        }
            //        if (column % 2 == 0)
            //        {

            //        }

            //    }
            //}
        }

        public void Start()
        {
            int playerIndex = new Random().Next(Players.Length);

            while (GetWinner() != null)
            {
                Player player = Players[playerIndex];

                DisplayHUD();
                Console.WriteLine($"Player {player.Name}, it's your turn.");

                Coordinate pieceCoordinate;
                Coordinate destination;
                Response response;

                do
                {
                    Console.Write("Select a piece to move: ");

                    pieceCoordinate = new Coordinate(Console.ReadLine());
                    response = IsPieceValid(pieceCoordinate);

                    if (!response.IsValid)
                    {
                        Console.Clear();
                        Console.WriteLine(response.Message);
                    }
                } while (!response.IsValid);

                do
                {
                    Console.Write("Now choose a destination: ");

                    destination = new Coordinate(Console.ReadLine());
                    response = IsDestinationValid(destination);

                    if (!response.IsValid)
                    {
                        Console.Clear();
                        Console.WriteLine(response.Message);
                    }
                } while (!response.IsValid);

                Move(pieceCoordinate, destination);
                ChangeTurn(ref playerIndex);
            }

            Console.WriteLine($"Congratulations, {Winner.Name}, you won with {Winner.NumberPieces} piece(s) ahead!");
        }

        public void CommandRoute(string command)
        {
            if (command.StartsWith("/ff"))
            {
                Surrender();
            }
            else
            {
                Console.WriteLine($"{command} was not recognized, please try again.");
            }
        }

        public void Surrender()
        {

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
            index %= Players.Length;
        }

        private void DisplayHUD()
        {
            Console.Clear();
            DisplayScore();
            Console.WriteLine();
            DisplayTable();
        }

        private void DisplayScore()
        {
            Console.WriteLine($"[{Players[0].Name}] 1 vs 2 [{Players[1].Name}]"); // Player should have num Pieces?
            // Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}"); // Format
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
                    board += " " + Board[row, column].Character + " |";
                }

                board += Environment.NewLine + GetLine(displayRowLength);
            }

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
