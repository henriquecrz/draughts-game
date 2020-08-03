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
                        CreateCommand(command);
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
            PlayMenu.Show();

            while (Game.Players.Count < Constant.NUMBER_OF_PLAYERS_REQUIRED)
            {
                // CreatePlayer();
            }

            // Mandar para uma tela que pergunta sobre os jogadores, se deseja usar ou criar

            Match match = new Match();

            match.Start();
        }

        private static void CreateCommand(string command)
        {
            Response response = new Response();
            string name = string.Empty;
            string[] splittedCommand = command.Split(Constant.SPLIT_SEPARATOR, Constant.SPLIT_COUNT);

            if (Utils.ContainsParam(splittedCommand))
            {
                name = splittedCommand[Constant.COMMAND_PARAMETER_INDEX];
                response = Game.IsNameInputValid(name);

                if (!response.IsValid)
                {
                    Console.Clear();
                    Console.WriteLine(response.Message);
                }
            }

            while (!response.IsValid)
            {
                Console.Write(Constant.NAME_INPUT_LABEL);

                name = Console.ReadLine();
                response = Game.IsNameInputValid(name);

                if (!response.IsValid)
                {
                    Console.Clear();
                    Console.WriteLine(response.Message);
                }
                else if (name == Command.QUIT)
                {
                    return;
                }
            }

            Game.AddPlayer(new Player(name));
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
