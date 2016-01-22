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
            var cf = StandingOn as ContainerField;
            if (cf != null)
                cf.ClearPrevious(this);

            AvailableMoves = MovesThisTurn;

            var sf = Game.Current.Board.GetSpawnPointForPlayer(Owner) as SpawnField;

            sf.Children.Add(this);
            StandingOn = FieldBeforeMove;

            _traversedFields.Clear();
        }

        public void EndMove()
        {
            _traversedFields.Clear();
            //_traversedFields.Add(StandingOn);
        }

        public abstract bool CanHit(Player player);
    }
}