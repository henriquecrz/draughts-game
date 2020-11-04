namespace DraughtsGame
{
    public class Winner : Player
    {
        public Winner(string name, char character, int numberPieces) : base(name)
        {
            NumberPieces = numberPieces;
        }

        public int NumberPieces { get; }
    }
}
