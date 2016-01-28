using Baricade.Core.Fields;
using System.Collections.Generic;
using System.Linq;

namespace Baricade.Core.Movables
{
    public abstract class Movable
    {
        List<BaseField> _traversedFields;

        public Movable()
        {
            _traversedFields = new List<BaseField>();
        }

        public BaseField StandingOn { get; internal set; }
        public Player Owner { get; internal set; }
        public int AvailableMoves { get; internal set; }
        public bool IsHit { get; internal set; }
        public BaseField FieldBeforeMove { get; internal set; }
        public int MovesThisTurn { get; internal set; }

        public bool HasMovesLeft => AvailableMoves > 1;
        public bool IsFirstMove => MovesThisTurn == AvailableMoves;
        public bool IsLastMove => AvailableMoves == 1;

        public virtual bool Move(Direction direction)
        {           
            var nextField = StandingOn.GetField(direction) as ContainerField;

            if (nextField == null)
                return false;
            if (_traversedFields.Contains(nextField))
                return false;

            var isAccepted = nextField.AcceptMove(this);

            if (isAccepted)
            {
                nextField.Place(this);
                AvailableMoves--;
                _traversedFields.Add(StandingOn);
            }              

            if (AvailableMoves == 0)
                EndMove();

            return isAccepted;
        }

        public void StartMove(int moves)
        {
            FieldBeforeMove = StandingOn;
            AvailableMoves = moves;
            MovesThisTurn = moves;
        }

        public void ResetMove()
        {
            AvailableMoves = MovesThisTurn;
            _traversedFields.Clear();

            if(StandingOn is ContainerField)
            {
                var containerField = (ContainerField)StandingOn;
                containerField.TempChild = null;
            }

            if(FieldBeforeMove is ContainerField)
            {
                var containerField = (ContainerField)FieldBeforeMove;
                containerField.Child = this;
            }

            if(FieldBeforeMove is CollectionField)
            {
                if(StandingOn != FieldBeforeMove)
                {
                    var collectionField = (CollectionField)FieldBeforeMove;
                    collectionField.Children.Add(this);
                }
                StandingOn = FieldBeforeMove;
            }
            
        }

        public void EndMove()
        {
            _traversedFields.Clear();
        }

        public abstract bool CanHit(Player player);
    }
}