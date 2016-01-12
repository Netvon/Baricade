using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Movables
{
    public class Pawn : Movable
    {
        

        public Player OwnedBy { get; set; }

        public bool CanBeHit { get; set; }
    }
}
