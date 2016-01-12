using Baricade.Core.Fields;
using System.Collections.Generic;
using System.Linq;

namespace Baricade.Core.Movables
{
    public abstract class Movable
    {
        List<Field> _traversedFields;

        public Movable()
        {
            _traversedFields = new List<Field>();
        }

        public Field StandingOn { get; internal set; }
        protected virtual bool ClearTraveredFieldOnEnd => true;

        public virtual bool Move(Direction direction)
        {
            var nextField = StandingOn.GetField(direction);
            if (_traversedFields.Contains(nextField))
                return false;

            var m = nextField.GetContainingMovable();

            if(nextField.CanBeMovedTo && m != null)
            {

            }

            return false;
        }

        public virtual void EndMove()
        {
            if(ClearTraveredFieldOnEnd)
                _traversedFields.Clear();
        }
    }
}