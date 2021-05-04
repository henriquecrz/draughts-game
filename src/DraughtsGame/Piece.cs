using System;
using DraughtsGame.Models;

namespace DraughtsGame
{
    public class Piece : IPiece
    {
        public Piece(char character)
        {
            Character = IsCharacterValid(character) ? char.ToLower(character) : throw new ArgumentException("Character must be a letter.");
            Type = PieceType.Men;
        }

        public char Character { get; private set; }

        public PieceType Type { get; private set; }

        public bool IsCharacterValid(char character) => char.IsLetter(character);

        public void BecomeKing()
        {
            Character = char.ToUpper(Character);
            Type = PieceType.King;
        }
    }
}
