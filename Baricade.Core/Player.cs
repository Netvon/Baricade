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
        public Player(int number)
        {
            Number = number;
        }

        public int Number { get; }
        List<Pawn> Pawns { get; set; }
    }
}
