using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    public abstract class CollectionField : Field
    {
        public CollectionField()
        {
            Children = new List<Movable>();
        }

        public List<Movable> Children { get; set; }

        public override bool IsEmpty => Children.Count == 0;

        public override bool AcceptMovable(Movable movable)
        {
            Children.Add(movable);
            return true;
        }
    }
}
