using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core
{
    public class Game
    {
        public Game(params Player[] players)
        {
            Players = players;
            Board = new Board(this);
        }

        public IEnumerable<Player> Players { get; }
        public Board Board { get;}
    }
}
