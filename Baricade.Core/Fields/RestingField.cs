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
        public override bool AcceptMove(Movable movable)
        {
            if(movable.IsLastMove && !IsEmpty)
            {
                return false;
            }

            if(movable is Movables.Baricade)
            {
                return false;
            }

            return base.AcceptMove(movable);
        }
    }
}
