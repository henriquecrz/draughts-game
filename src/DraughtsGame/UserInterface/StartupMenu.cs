using System;

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
                Console.WriteLine("Type \"Play\" or \"Quit\".");
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
                    {
                        PlayCommand();
                        break;
                    }
                case true when command.StartsWith(Command.CREATE):
                    {
                        CreatePlayer(command);
                        break;
                    }
                case true when command.StartsWith(Command.STATISTICS):
                    {
                        StatisticsCommand();
                        break;
                    }
                case true when command.StartsWith(Command.QUIT):
                    {
                        QuitCommand();
                        break;
                    }
                default:
                    {
                        HelpCommand(command);
                        break;
                    }
            }
        }

        private static void PlayCommand()
        {
            do
            {
                if (Game.Players.Count != 0)
                {
                    Game.ShowPlayers();
                }

                if (Game.Players.Count < Constant.NUMBER_OF_PLAYERS_REQUIRED)
                {
                    Console.WriteLine("First, we need to create at least {0} players;", Constant.NUMBER_OF_PLAYERS_REQUIRED);

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
            string name = string.Empty;
            string[] splittedCommand = command.Split(Constant.SPLIT_SEPARATOR, Constant.SPLIT_COUNT);

            if (Command.ContainsParam(splittedCommand))
            {
                name = splittedCommand[Constant.NAME_PARAMETER_INDEX];
                Response response = Game.IsNameInputValid(name);

                if (response.IsValid)
                {
                    Game.AddPlayer(new Player(name));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(response.Message);
                    Console.WriteLine();
                    CreatePlayer();
                }
            }
        }

        private static void CreatePlayer()
        {
            string name = string.Empty;
            Response response = new Response();

            do
            {
                Console.Write(Label.NAME_INPUT);

                name = Console.ReadLine();
                response = Game.IsNameInputValid(name);

                // Console.Read

                if (response.IsValid)
                {
                    Game.AddPlayer(new Player(name));
                }
                else if (name == Command.QUIT)
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(response.Message);
                    Console.WriteLine();
                }
            } while (!response.IsValid);
        }

        private static void StatisticsCommand()
        {
            throw new NotImplementedException();
        }

        private static void QuitCommand()
        {
            _quit = true;
        }

        private static void HelpCommand(string command)
        {
            Console.WriteLine(Command.NOT_RECOGNIZED, command);
            Console.WriteLine();
            Console.WriteLine("GradeBook accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
            Console.WriteLine();
            Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }
    }
}
