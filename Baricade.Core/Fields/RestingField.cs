using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    public class RestingField : ContainerField
    {
        public override bool AcceptMovable(Movable movable)
        {
            if (movable.GetType() == typeof(Movables.Baricade))
                return false;

            if (!IsEmpty && Child.Owner != movable.Owner)
                return false;

            return base.AcceptMovable(movable);
        }
    }
}
