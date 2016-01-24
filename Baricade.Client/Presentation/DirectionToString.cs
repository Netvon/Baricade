using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.Presentation
{
    class DirectionToString
    {
        public static string Convert(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return "↑";
                case Direction.Down:
                    return "↓";
                case Direction.Left:
                    return "←";
                case Direction.Right:
                    return "→";
            }

            return null;
        }
    }
}
