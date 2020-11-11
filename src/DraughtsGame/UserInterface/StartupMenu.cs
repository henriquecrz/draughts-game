using System;
using DraughtsGame.Constants;
using DraughtsGame.Exceptions;

namespace DraughtsGame.UserInterface
{
    public static class StartupMenu
    {
        private static bool _quit = false;

        public static void Show()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("#==========================#");
                Console.WriteLine("# Henrique's Draughts Game #");
                Console.WriteLine("#==========================#");
                Console.WriteLine();
                Console.Write(">> What would you like to do? ");

                var command = Console.ReadLine().Trim().ToLower();

                CommandRoute(command);
            } while (!_quit);

            Console.WriteLine("See you soon!");
            Console.Read();
        }

        private static void CommandRoute(string command)
        {
            switch (true)
            {
                case true when command.StartsWith(Command.PLAY):
                    Play();
                    break;
                case true when command.StartsWith(Command.CREATE_PLAYER):
                    CreatePlayer(command);
                    break;
                case true when command.StartsWith(Command.STATISTICS):
                    ShowStatistics();
                    break;
                case true when command.StartsWith(Command.QUIT):
                    Quit();
                    break;
                default:
                    Help(command);
                    break;
            }
        }

        private static void Play()
        {
            do
            {
                Game.ShowPlayers();

                if (Game.Players.Count < Configuration.NUMBER_OF_PLAYERS_REQUIRED)
                {
                    Console.WriteLine();
                    Console.WriteLine("You need to create at least {0} players.", Configuration.NUMBER_OF_PLAYERS_REQUIRED);
                    Game.RunOverPlayers(CreatePlayer);
                }
                else
                {
                    Console.WriteLine("Select {0} players to start a new match.");
                }

                Console.Clear();
                Console.WriteLine("#==========================#");
                Console.WriteLine("#                          #");
                Console.WriteLine("#==========================#");
                Console.WriteLine();
                Console.WriteLine("Type \"Play\" or \"Quit\".");
                Console.Write(">> What would you like to do? ");

                var command = Console.ReadLine().Trim().ToLower();

                CommandRoute(command);
            } while (!_quit);
        }

        private static void CreatePlayer(string command)
        {
            string[] splittedCommand = command.Split(Separator.SPACE, Command.NUMBER_OF_SUBSTRINGS);

            if (Command.ContainsParam(splittedCommand))
            {
                string name = splittedCommand[Command.NAME_PARAMETER_INDEX];
                Response response = Game.IsNameInputValid(name);

                if (response.IsValid)
                {
                    Game.AddPlayer(new Player(name));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    CreatePlayer();
                }
            }
            else
            {
                throw new InvalidCommandException();
            }
        }

        private static void CreatePlayer()
        {
            Response response = new Response();

            do
            {
                Console.Write(Label.NAME_INPUT);

                string name = Console.ReadLine().Trim();

                if (name.ToLower() == Command.QUIT)
                {
                    return;
                }

                response = Game.IsNameInputValid(name);

                if (response.IsValid)
                {
                    Game.AddPlayer(new Player(name));
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            } while (!response.IsValid);
        }

        private static void ShowStatistics()
        {
            throw new NotImplementedException();
        }

        private static void Quit()
        {
            _quit = true;
        }

        private static void Help(string command)
        {
            Console.WriteLine(Command.NOT_RECOGNIZED, command);
            Console.WriteLine();
            Console.WriteLine("The menu accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine(" Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
            Console.WriteLine();
            Console.WriteLine(" Load 'Name' - Loads the gradebook with the provided 'Name'.");
            Console.WriteLine();
            Console.WriteLine(" Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine(" Quit - Exits the game");
        }
    }
}
