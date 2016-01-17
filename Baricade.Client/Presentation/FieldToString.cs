using Baricade.Core.Fields;

namespace Baricade.Client.Presentation
{
    class FieldToString
    {
        public static string Convert(Field field)
        {
            var cf = field as ContainerField;
            if(cf != null)
            {
                if (cf.Child is Core.Movables.Baricade)
                    return "B";
            }

            if (field is FinishField)
                return "*";

            if (field is SpawnField)
            {
                var sf = field as SpawnField;
                return $"{sf.Player.Pawns.Count}";
            }

            if (field is RestingField)
                return "R";

            if (field is ForestField)
                return "F";

            return "x";
        }
    }
}
