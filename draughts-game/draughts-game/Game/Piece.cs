using System;

namespace draughts_game.Game
{
    class Piece : IPiece
    {
        private PieceType _type;

        public Piece(Player player)
        {
            Owner = player;
            _type = PieceType.Men;
        }

        public Player Owner { get; }

        public PieceType Type
        {
            get => _type;
            set
            {
                if (value == PieceType.Men && _type == PieceType.King)
                {
                    throw new ArgumentException("Once a \"king\", the piece can not become a \"men\" again.");
                }

                _type = value;
            }
        }
    }
}
