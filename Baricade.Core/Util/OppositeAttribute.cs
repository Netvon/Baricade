using Baricade.Core.Fields;
using System;

namespace Baricade.Core.Util
{
    internal class OppositeAttribute : Attribute
    {
        public Direction Opposite { get; set; }

        public OppositeAttribute(Direction opposite)
        {
            Opposite = opposite;
        }
    }
}