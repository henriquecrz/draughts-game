using System.Collections.Generic;

namespace DraughtsGame
{
    public class Team
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
