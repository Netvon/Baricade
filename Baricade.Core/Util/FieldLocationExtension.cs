using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Util
{
    static class FieldLocationExtension
    {
        public static Direction Opposite(this Direction location)
        {
            var type = typeof(Direction);
            var memberInfo = type.GetMember(location.ToString());

            var attribute = memberInfo.First().GetCustomAttributes(typeof(OppositeAttribute), false);
            var opposite = attribute.First() as OppositeAttribute;

            return opposite.Opposite;
        }
    }
}
