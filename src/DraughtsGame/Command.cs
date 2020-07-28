using System;

namespace DraughtsGame
{
    public class Command
    {
        public const string PLAY = "play";

        public const string CREATE = "create";

        public const string STATISTICS = "stat";

        public const string QUIT = "quit";

        public const string NOT_RECOGNIZED = "\"{0}\" was not recognized, please try again.";
    }
}