namespace draughts_game.Game
{
    interface IPiece
    {
        public Player Owner { get; }

        public PieceType Type { get; set; }
    }
}
