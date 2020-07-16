using System;

namespace draughts_game.Draughts
{
    class Coordinate
    {
        private readonly int x;
        private readonly int y;

        public Coordinate(string coordinate)
        {
            string[] split = coordinate.Split(',');

            if (split.Length is 2)
            {
                if (!int.TryParse(split[0], out x))
                {
                    throw new Exception();
                }

                if (!int.TryParse(split[1], out y))
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }
        
        public int X { get => x; }
        
        public int Y { get => y; }
    }
}
