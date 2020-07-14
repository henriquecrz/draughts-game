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
                if (!IsNameValid(value))
                {
                    throw new ArgumentException("Name must have at least 1 and a maximum of 100 alphanumeric chars.");
                }

                _name = value;
            }
        }

        public char Character
        {
            get => _character;
            set
            {
                if (!char.IsLetter(value))
                {
                    throw new ArgumentException("Character must be a letter.");
                }

                _character = char.ToLower(value);
            }
        }

        public static bool IsNameValid(string name) => !string.IsNullOrWhiteSpace(name) && name.Length <= 100;
    }
}
