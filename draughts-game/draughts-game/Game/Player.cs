using System;

namespace draughts_game.Game
{
    class Player : IPlayer
    {
        private string _name;
        private char _character;

        public Player(string name, char character)
        {
            Name = name;
            Character = character;
        }

        public string Name
        {
            get => _name;
            set
            {
                Response response = IsNameValid(value);

                if (!response.IsValid)
                {
                    throw new ArgumentException(response.Message);
                }

                _name = value.Trim();
            }
        }

        public char Character
        {
            get => _character;
            set
            {
                Response response = IsCharValid(value);

                if (!response.IsValid)
                {
                    throw new ArgumentException("Character must be a letter.");
                }

                _character = char.ToLower(value);
            }
        }

        public static Response IsNameValid(string name)
        {
            string trimmedName = name.Trim();

            return !string.IsNullOrWhiteSpace(trimmedName) && trimmedName.Length <= 100 ?
                new Response(true, Constant.IS_VALID_MESSAGE) :
                new Response(false, Constant.INVALID_NAME_MESSAGE);
        }

        public static Response IsCharValid(char character)
        {
            return char.IsLetter(character) ?
                new Response(true, Constant.IS_VALID_MESSAGE) :
                new Response(false, Constant.INVALID_CHAR_MESSAGE);
        }
    }
}
