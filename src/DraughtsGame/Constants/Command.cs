namespace DraughtsGame
{
    public class Command
    {
        public const string PLAY = "play";

        public const string CREATE_PLAYER = "create";

        public const string STATISTICS = "stat";

        public const string QUIT = "quit";

        public const string NOT_RECOGNIZED = "\"{0}\" was not recognized, please try again.";

        public const int NUMBER_OF_SUBSTRINGS = 2;

        public const int NAME_PARAMETER_INDEX = 1;

        public static bool ContainsParam(string[] command) => command.Length > 1;
    }
}
