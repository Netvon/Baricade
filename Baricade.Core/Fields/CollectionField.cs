using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    abstract class CollectionField : Field
    {
        public List<Movable> Children { get; set; }

        public override bool CanContainMovable => false;
        public override bool CanContainMutlipleMovable => true;
        public override bool CanContainBaricade => false;

        public virtual int MaxChildren => int.MaxValue;

        public override bool IsEmpty => Children?.Count == 0;

        public override void AcceptMovable(Movable movable)
        {
            if(Children.Count < MaxChildren)
                Children.Add(movable);
        }
    }
}
