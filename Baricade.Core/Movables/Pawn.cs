using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Movables
{
    public class Pawn : Movable
    {
        public Pawn(int number, Player owned)
        {
            Number = number;
            Owner = owned;
        }

        public int Number { get; }

        public Player OwnedBy => Owner;

        public override bool CanHit(Player player)
        {
            if (player == OwnedBy)
                return false;

            return true;
        }

        public override void Place(Field placeOn)
        {
            if(placeOn.GetType() == typeof(FinishField))
            {
                Game.GetInstance().IsWon = true;
            }

            base.Place(placeOn);
        }
    }
}
