using System;
using System.Collections.Generic;
using System.Text;

namespace draughts_game.Draughts
{
    class Team
    {
        private string _tag;

        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public string Tag
        {
            get => _tag;
            set
            {
                _tag = value;
            }
        }

        public List<Player> Players { get; private set; }
    }
}
