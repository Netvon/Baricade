using Baricade.Core.Fields;

namespace Baricade.Core.Movables
{
    public abstract class Movable
    {
        public Field StandingOn { get; internal set; }

        public void Move(Direction direction)
        {

        }
    }
}