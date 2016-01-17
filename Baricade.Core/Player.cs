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

            Pawns = new List<Pawn>()
            {
                new Pawn(1),
                new Pawn(2),
                new Pawn(3),
                new Pawn(4)
            };

        }

        public Player(int number)
            :this(null, number)
        { }

        public int Number { get; }
        public List<Pawn> Pawns { get; }
        public Game Game { get; set; }
    }
}
