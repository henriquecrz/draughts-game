using System;

namespace DraughtsGame
{
    public class Match
    {
        public Match()
        {
            CreatePlayers(); // Players received from outside, Match does not have to create Players, so you have to create a class called Game (rename "Game" namespace) that will holds a list of matches and players
            CreateBoard();
        }

        public Player[] Players { get; private set; } // set? private?

        public Piece[,] Board { get; private set; } // set? private?

        public Winner Winner { get; private set; }

        private void CreatePlayers()
        {
            Players = new Player[Constant.NUMBER_OF_PLAYERS_REQUIRED];

            for (int i = 0; i < Players.Length; i += 1)
            {
                string nameInput;
                Response response;

                do
                {
                    Console.Write(Constant.NAME_INPUT_LABEL);

                    nameInput = Console.ReadLine();
                    response = IsNameInputValid(nameInput);

                    if (!response.IsValid)
                    {
                        Console.Clear();
                        Console.WriteLine(response.Message);
                    }
                } while (!response.IsValid);

                char charInput;

                do
                {
                    Console.Write(Constant.CHAR_INPUT_LABEL);

                    char.TryParse(Console.ReadLine(), out charInput);

                    response = IsCharInputValid(charInput);

                    if (!response.IsValid)
                    {
                        Console.Clear();
                        Console.WriteLine(response.Message);
                    }
                } while (!response.IsValid);

                Players[i] = new Player(nameInput, charInput);
            }
        }

        private void CreateBoard()
        {
            Board = new Piece[Constant.BOARD_SIZE, Constant.BOARD_SIZE];

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
            //if (Players.Count < Constant.MIN_NUMBER_OF_PLAYERS)
            //{
            //    Console.WriteLine(Constant.CREATE_PLAYERS_MESSAGE);

            //    CreatePlayers();
            //}

            int playerIndex = new Random().Next(Players.Length);

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

            Console.WriteLine($"Congratulations, {Winner.Name}, you won with {Winner.} piece(s) ahead!");
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

        private Response IsNameInputValid(string nameInput)
        {
            Response response = Player.IsNameValid(nameInput);
            bool isValid = response.IsValid;
            string message = response.Message;

            if (isValid && Array.Exists(Players, player => player.Name == nameInput))
            {
                isValid = false;
                message = Constant.EXISTING_PLAYER_NAME_MESSAGE;
            }

            return new Response(isValid, message);
        }

        private Response IsCharInputValid(char character)
        {
            Response response = Player.IsCharValid(character);
            bool isValid = response.IsValid;
            string message = response.Message;

            if (isValid && Array.Exists(Players, player => player.Character == character))
            {
                isValid = false;
                message = Constant.EXISTING_PLAYER_CHAR_MESSAGE;
            }

            return new Response(isValid, message);
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
                    board += " " + Board[row, column].Character + " |";
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
            return new Player("a", 'a');
        }
    }
}
