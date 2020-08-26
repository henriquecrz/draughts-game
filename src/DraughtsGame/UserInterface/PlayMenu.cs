using System;

namespace DraughtsGame.UserInterface
{
    public static class PlayMenu
    {
        // private static bool _quit = false;

        // public static void Show()
        // {
        //     do
        //     {
        //         if (Game.Players.Count != 0)
        //         {
        //             Game.ShowPlayers();
        //         }

        //         if (Game.Players.Count < Constant.NUMBER_OF_PLAYERS_REQUIRED)
        //         {
        //             Console.WriteLine("First, we need to create at least {0} players;", Constant.NUMBER_OF_PLAYERS_REQUIRED);

        //             Game.RunOverPlayers();
        //         }
        //         else
        //         {
        //             Console.WriteLine("Select {0} players to start a new match.");
        //         }

        //         Console.Clear();
        //         Console.WriteLine("#==========================#");
        //         Console.WriteLine("#                          #");
        //         Console.WriteLine("#==========================#");
        //         Console.WriteLine();
        //         Console.WriteLine("Type \"Play\" or \"Quit\".");
        //         Console.Write(">> What would you like to do? ");

        //         var command = Console.ReadLine().Trim().ToLower();

        //         CommandRoute(command);
        //     } while (!_quit);

        //     Console.WriteLine("See you soon!");
        //     Console.Read();
        // }

        // private static void CommandRoute(string command)
        // {
        //     switch (true)
        //     {
        //         case true when command.StartsWith(Command.CREATE):
        //             {

        //                 break;
        //             }
        //         default:
        //             {
        //                 Console.WriteLine(Command.NOT_RECOGNIZED, command);
        //                 break;
        //             }
        //     }
        // }

        // public static void CreatePlayer()
        // {
        //     for (int i = 0; i < Game.Players.Count; i += 1)
        //     {
        //         string nameInput;
        //         Response response;

        //         do
        //         {
        //             Console.Write(Constant.NAME_INPUT_LABEL);

        //             nameInput = Console.ReadLine();
        //             response = Game.IsNameInputValid(nameInput);

        //             if (!response.IsValid)
        //             {
        //                 Console.Clear();
        //                 Console.WriteLine(response.Message);
        //             }
        //         } while (!response.IsValid);

        //         char charInput;

        //         do
        //         {
        //             Console.Write(Constant.CHAR_INPUT_LABEL);

        //             char.TryParse(Console.ReadLine(), out charInput);

        //             response = Game.IsCharInputValid(charInput);

        //             if (!response.IsValid)
        //             {
        //                 Console.Clear();
        //                 Console.WriteLine(response.Message);
        //             }
        //         } while (!response.IsValid);

        //         Game.AddPlayer(new Player(nameInput, charInput));
        //     }
        // }
    }
}
