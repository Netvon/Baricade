using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Movables
{
    public class Baricade : Movable
    {
        public override bool CanHit(Player player)
        {
            return true;
        }
    }
}
