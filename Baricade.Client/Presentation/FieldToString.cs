using Baricade.Core;
using Baricade.Core.Fields;
using Baricade.Core.Movables;

namespace Baricade.Client.Presentation
{
    class FieldToString
    {
        public static string Convert(BaseField field)
        {
            var container = field as ContainerField;
            if(container != null)
            {
                Movable child = container.TempChild;

                if (Game.Current.IsBaricadeMoveModeActive)
                {
                    if (Game.Current.BaricadeCursor == field)
                        return MovableToString.Convert(child);
                }

                if (child == null)
                    child = container.Child;

                if (child != null)
                    return MovableToString.Convert(child);
            }

            if (field is FinishField)
                return "*";

            if (field is SpawnField)
            {
                var sf = field as SpawnField;
                return $"{sf.Children.Count}";
            }

            if (field is RestingField)
                return "R";

            if (field is ForestField)
                return "F";

            return "x";
        }
    }
}
