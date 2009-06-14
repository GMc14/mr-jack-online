using System;
using System.Collections.Generic;

namespace MrJack
{
    public class GameMessage
    {
        public int Header;
        public string Content;

        public int Round;
        public List<GameMove> moves;
    }
}
