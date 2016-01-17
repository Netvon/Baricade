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
        public Movable Child { get; internal set; }

        public Movable TempChild { get; internal set; }

        public override bool IsEmpty => Child == null;

        public override bool AcceptMovable(Movable movable)
        {
            if (movable.GetType() == typeof(Movables.Baricade) && !IsEmpty)
                return false;

            if (!IsEmpty &&
                Child.GetType() == typeof(Movables.Baricade) &&
                movable.AvailableMoves > 1)
                return false;

            if (IsEmpty)
            {
                var cf = movable.StandingOn as ContainerField;
                if (cf != null)
                    cf.Child = null;

                var collf = movable.StandingOn as CollectionField;
                if (collf != null)
                    collf.Children.Remove(movable);

                Child = movable;
            }
            else if (!IsEmpty &&
               movable.AvailableMoves > 1)
            {
                TempChild = movable;
            }
            else if (!IsEmpty &&
                Child.Owner != movable.Owner &&
                Child.CanHit(movable.Owner) && movable.AvailableMoves == 1)
            {
                Child.Hit();

                if(Child.GetType() == typeof(Movables.Baricade))
                {
                    Game.GetInstance().SetBaricadeMoveMode(Child);
                }
                else
                {
                    var sendTo = Game.GetInstance().Board.GetReturnPoint(Child);
                    sendTo.AcceptMovable(Child);
                }

                Child = movable;
            }

            movable.Place(this);

            return true;
        }
    }
}
