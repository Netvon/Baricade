using Baricade.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    public enum Direction
    {
        None,
        [Opposite(Down)]
        Up,
        [Opposite(Up)]
        Down,
        [Opposite(Right)]
        Left,
        [Opposite(Left)]
        Right        
    }
}
