using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.Presentation
{
    class MovableToString
    {
        public static string Convert(Movable field)
        {
            var cf = field as Pawn;
            if (cf != null)
                return $"{cf.Number}";

            return "░";
        }
    }
}
