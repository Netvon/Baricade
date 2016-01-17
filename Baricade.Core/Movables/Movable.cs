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
        public Field FieldBeforeMove { get; internal set; }
        public int MovesThisTurn { get; internal set; }

        public virtual bool Move(Direction direction)
        {
            IsHit = false;

            var nextField = StandingOn.GetField(direction);

            if (nextField == null || nextField is SpawnField)
                return false;
            if (_traversedFields.Contains(nextField))
                return false;

            var @out = nextField.AcceptMovable(this);

            if (@out)
            {
                AvailableMoves--;
                _traversedFields.Add(nextField);
            }              

            if (AvailableMoves == 0)
                EndMove();

            return @out;
        }

        public virtual void Place(Field placeOn)
        {
            StandingOn = placeOn;
        }

        public void StartMove(int moves)
        {
            FieldBeforeMove = StandingOn;
            AvailableMoves = moves;
            MovesThisTurn = moves;
        }

        public void ResetMove()
        {
            var cf = StandingOn as ContainerField;
            if (cf != null)
                cf.ClearPrevious(this);

            AvailableMoves = MovesThisTurn;

            var sf = Game.GetInstance().Board.GetSpawnPointForPlayer(Owner) as SpawnField;

            sf.Children.Add(this);
            StandingOn = FieldBeforeMove;

            _traversedFields.Clear();
        }

        public void EndMove()
        {
            _traversedFields.Clear();
            _traversedFields.Add(StandingOn);
        }

        public void Hit()
        {
            IsHit = true;
        }

        public abstract bool CanHit(Player player);
    }
}