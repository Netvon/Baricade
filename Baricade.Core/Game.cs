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

            foreach (var p in Players)
                p.Game = this;

            Dice = new Dice(6);
        }

        public IEnumerable<Player> Players { get; }
        public Board Board { get; }
        public Dice Dice { get; }
    }
}
