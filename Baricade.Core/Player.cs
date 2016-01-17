using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core
{
    public class Player
    {
        public Player(Game game, int number)
        {
            Game = game;
            Number = number;
        }

        public Player(int number)
            :this(null, number)
        {

        }

        public int Number { get; }
        List<Pawn> Pawns { get; }
        public Game Game { get; set; }
    }
}
