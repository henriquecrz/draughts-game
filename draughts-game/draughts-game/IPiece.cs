namespace draughts_game
{
    interface IPiece
    {
        public Player Owner { get; }

        public PieceType Type { get; set; }
    }
}
