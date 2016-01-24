using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Core.Movables;

namespace Baricade.Core.Fields
{
    public class FinishField : ContainerField
    {
        public override bool AcceptMove(Movable movable)
        {
            if (movable.GetType() == typeof(Movables.Baricade))
                return false;

            return base.AcceptMove(movable);
        }

        public override void Place(Movable movable)
        {
            base.Place(movable);

            Game.Current.SetWin();
        }
    }
}
