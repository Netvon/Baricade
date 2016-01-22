using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Core.Movables;

namespace Baricade.Core.Fields
{
    class CityField : ContainerField
    {
        public override CollectionField SendToAfterHit(Pawn pawn)
        {
            return Board.Forest;
        }
    }
}
