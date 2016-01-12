using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Core.Movables;

namespace Baricade.Core.Fields
{
    class BottomField : Field
    {
        public override void AcceptMovable(Movable movable)
        {
            throw new NotImplementedException();
        }

        public override bool CanContainBaricade => false;
        public override bool CanContainMovable => true;
        public override bool CanContainMutlipleMovable => false;
    }
}
