using System;
using System.Text;

namespace DraughtsGame.Constants
{
    public class Label
    {
        public const string INTENT_QUESTION = ">> What would you like to do? ";

        public const string CONTINUE = "Press any key to continue...";

        public const string NAME_INPUT = "Insert your user name: ";

        public const string CHAR_INPUT = "Insert a char you'll use. Remember, you can only use one letter: ";

        static Label()
        {
            FillTitle();
        }

        public static string Title { get; private set; }

        private static void FillTitle()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("#==========================#");
            stringBuilder.Append(Environment.NewLine + "# Henrique's Draughts Game #");
            stringBuilder.Append(Environment.NewLine + "#==========================#");
            stringBuilder.Append(Environment.NewLine);

            Title = stringBuilder.ToString();
        }
    }
}
