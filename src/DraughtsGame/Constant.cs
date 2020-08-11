namespace DraughtsGame
{
    public class Constant
    {
        public const int BOARD_SIZE = 8;

        public const int NUMBER_OF_PIECES = 12;

        public const int NUMBER_OF_PLAYERS_REQUIRED = 2;

        public const char SPLIT_SEPARATOR = ' ';

        public const int SPLIT_COUNT = 2;

        public const int NAME_PARAMETER_INDEX = 1;

        public const string IS_VALID_MESSAGE = "Ok";

        public const string NAME_INPUT_LABEL = "Insert your user name: ";

        public const string CHAR_INPUT_LABEL = "Insert a char you'll use. Remember, you just can use a letter: ";

        public const string INVALID_NAME_MESSAGE = "Name must have at least 1 and a maximum of 100 alphanumeric chars. Try again.";

        public const string INVALID_CHAR_MESSAGE = "Character must be 1 letter. Try again.";

        public const string EXISTING_PLAYER_NAME_MESSAGE = "There is already a player with this name. Try another one.";

        public const string EXISTING_PLAYER_CHAR_MESSAGE = "There is already a player using this char. Try another one.";
    }
}
