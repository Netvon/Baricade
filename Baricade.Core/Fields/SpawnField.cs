﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Core.Movables;

namespace Baricade.Core.Fields
{
    public class SpawnField : CollectionField
    {   
        public SpawnField(Player player)
        {
            Player = player;
            
            foreach(var pawn in player.Pawns)
            {
                pawn.StandingOn = this;
            }

            Children.AddRange(player.Pawns);
        }

        public Player Player { get; }

        public override bool AcceptMove(Movable movable)
        {
            if (movable.GetType() == typeof(Movables.Baricade))
                return false;

            if (movable.Owner != Player && !movable.IsHit)
                return false;

            if (Children.Count < 4)
                return base.AcceptMove(movable);

            return false;
        }
    }
}
