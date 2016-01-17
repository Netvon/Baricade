using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Core.Movables;

namespace Baricade.Core.Fields
{
    class ForestField : CollectionField
    {
        public override bool AcceptMovable(Movable movable)
        {
            if (!movable.IsHit || movable.GetType() == typeof(Movables.Baricade))
                return false;

            return base.AcceptMovable(movable);
        }
    }
}
