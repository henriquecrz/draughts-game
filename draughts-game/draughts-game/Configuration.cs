using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game
{
    class Configuration
    {
        public Configuration()
        {
            BoardSize = Constant.BOARD_SIZE;
        }

        public int BoardSize;
    }
}
