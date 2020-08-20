using System;
using System.Collections.Generic;

namespace DraughtsGame
{
    public static class Game
    {
        static Game()
        {
            Players = new List<Player>();
            Matches = new List<Match>();
        }

        public static List<Player> Players { get; } // private set?

        public static List<Match> Matches { get; } // private set?

        public static void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public static void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public static Response IsNameInputValid(string nameInput)
        {
            Response response = Player.IsNameValid(nameInput);
            bool isValid = response.IsValid;
            string message = response.Message;

            if (isValid && Players.Exists(player => player.Name == nameInput))
            {
                isValid = false;
                message = Message.EXISTING_PLAYER_NAME;
            }

            return new Response(isValid, message);
        }

        public static Response IsCharInputValid(char character)
        {
            Response response = Player.IsCharValid(character);
            bool isValid = response.IsValid;
            string message = response.Message;

            if (isValid && Players.Exists(player => player.Character == character))
            {
                isValid = false;
                message = Message.EXISTING_PLAYER_CHAR;
            }

            return new Response(isValid, message);
        }

        public static void ShowPlayers()
        {
            Console.WriteLine("#=========#");
            Console.WriteLine("# Players #");
            Console.WriteLine("#=========#");
            Console.WriteLine();

            if (Players.IsEmpty())
            {
                Console.WriteLine("There is no players registered.");
            }
            else
            {
                for (int i = 0; i < Players.Count; i += 1)
                {
                    Console.WriteLine($"{i + 1} - {Players[i].Name}");
                }
            }
        }

        public static void RunOverPlayers(Action method)
        {
            while (Players.Count < Constant.NUMBER_OF_PLAYERS_REQUIRED)
            {
                method.Invoke();
            }
        }
    }
}
