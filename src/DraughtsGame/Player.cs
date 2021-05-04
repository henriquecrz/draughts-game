using System;
using DraughtsGame.Constants;
using DraughtsGame.Models;

namespace DraughtsGame
{
    public class Player : IPlayer
    {
        private string _name;
        private char _character;

        public Player(string name)
        {
            Name = name;
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
                new Response(true, Message.IS_VALID) :
                new Response(false, Message.INVALID_NAME);
        }

        public static Response IsCharValid(char character)
        {
            return char.IsLetter(character) ?
                new Response(true, Message.IS_VALID) :
                new Response(false, Message.INVALID_CHAR);
        }
    }
}
