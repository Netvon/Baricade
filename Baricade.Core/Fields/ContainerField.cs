using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    public class ContainerField : Field
    {
        public Movable Child { get; set; }

        public override bool CanContainMovable => true;
        public override bool CanContainMutlipleMovable => false;
        public override bool CanContainBaricade => true;
        public override bool IsEmpty => Child == null;

        public override void AcceptMovable(Movable movable)
        {
            throw new NotImplementedException();
        }
    }
}
