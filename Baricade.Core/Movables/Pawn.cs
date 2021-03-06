﻿using Baricade.Core.Fields;
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

        public override bool CanHit(Player player)
        {
            if (player == Owner && IsLastMove)
                return false;

            return true;
        }
    }
}
