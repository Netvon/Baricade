using Baricade.Core;
using Baricade.Core.Fields;
using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.Presentation
{
    class FieldToColors
    {
        public static Colors Convert(BaseField field)
        {
            if(Game.Current.IsBaricadeMoveModeActive &&
                field == Game.Current.BaricadeCursor)
            {
                return new Colors(ConsoleColor.Black, ConsoleColor.Cyan);
            }

            if(field is ContainerField)
            {
                var container = (ContainerField)field;

                Pawn child = container.TempChild as Pawn;

                if (child == null)
                    child = container.Child as Pawn;

                if (child != null)
                    return GetColor(child.Owner.Number);
            }

            if(field is SpawnField)
            {
                var spawnField = (SpawnField)field;

                int number = spawnField.Player.Number;
                return GetColor(number);
            }

            if(field is RestingField)
            {
                return Colors.WithDefaultBackground(ConsoleColor.DarkGray);
            }

            return Colors.Default;
        }

        static Colors GetColor(int number)
        {
            switch (number)
            {
                case 1:
                    return Colors.WithDefaultBackground(ConsoleColor.Red);
                case 2:
                    return Colors.WithDefaultBackground(ConsoleColor.Green);
                case 3:
                    return Colors.WithDefaultBackground(ConsoleColor.Yellow);
                case 4:
                    return Colors.WithDefaultBackground(ConsoleColor.Blue);

                default:
                    return Colors.WithDefaultBackground(ConsoleColor.Magenta);
            }
        }
    }
}
