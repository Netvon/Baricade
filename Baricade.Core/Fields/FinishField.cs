using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Core.Movables;

namespace Baricade.Core.Fields
{
    public class FinishField : ContainerField
    {
        public override bool AcceptMovable(Movable movable)
        {
            if (movable.GetType() == typeof(Movables.Baricade))
                return false;

            var @out = base.AcceptMovable(movable);

            if (@out)
            {
                // TODO: win logic
            }

            return @out;
        }
    }
}
