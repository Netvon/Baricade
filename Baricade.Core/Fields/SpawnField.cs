using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    class SpawnField : CollectionField
    {   
        public SpawnField(Player player)
        {
            Player = player;
        }

        public override int MaxChildren => 4;
        public Player Player { get; }
    }
}
