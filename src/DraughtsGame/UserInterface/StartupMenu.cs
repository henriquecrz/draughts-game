using System;

namespace DraughtsGame.UserInterface
{
    public static class StartupMenu
    {
        private static bool _quit = false;

        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("#==========================#");
            Console.WriteLine("# Henrique's Draughts Game #");
            Console.WriteLine("#==========================#");

            do
            {
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
                case true when command.StartsWith("play"): // Add constant
                    {
                        Menu.Show();

                        while (Game.Players.Count < Constant.NUMBER_OF_PLAYERS_REQUIRED)
                        {
                            CreatePlayer();
                        }

                        // Mandar para uma tela que pergunta sobre os jogadores, se deseja usar ou criar
                        
                        Match match = new Match();

                        match.Start();
                        break;
                    }
                case true when command.StartsWith("stat"): // Add constant
                    {
                        // Redirecionar para 1 menu de estatísticas "statistics"

                        break;
                    }
                default:
                    {
                        Quit();

                        // Message goes here?

                        break;
                    }
            }
        }

        public static void CreatePlayer()
        {
            for (int i = 0; i < Game.Players.Count; i += 1)
            {
                string nameInput;
                Response response;

                do
                {
                    Console.Write(Constant.NAME_INPUT_LABEL);

                    nameInput = Console.ReadLine();
                    response = Game.IsNameInputValid(nameInput);

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

                    response = Game.IsCharInputValid(charInput);

                    if (!response.IsValid)
                    {
                        Console.Clear();
                        Console.WriteLine(response.Message);
                    }
                } while (!response.IsValid);

                Game.AddPlayer(new Player(nameInput, charInput));
            }
        }

        private static void Quit()
        {
            _quit = true;
        }
    }
}
