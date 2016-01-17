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
        public Player Owner { get; internal set; }
        public int AvailableMoves { get; internal set; }
        public bool IsHit { get; internal set; }

        public virtual bool Move(Direction direction)
        {
            IsHit = false;

            var nextField = StandingOn.GetField(direction);
            if (_traversedFields.Contains(nextField))
                return false;

            var @out = nextField.AcceptMovable(this);

            if (@out)
                AvailableMoves--;

            if (AvailableMoves == 0)
                EndMove();

            return @out;
        }

        public void Place(Field placeOn)
        {
            StandingOn = placeOn;
        }

        public void StartMove(int moves)
        {
            AvailableMoves = moves;
        }

        public void EndMove()
        {
            _traversedFields.Clear();
        }

        public void Hit()
        {
            IsHit = true;
        }

        public abstract bool CanHit(Player player);
    }
}