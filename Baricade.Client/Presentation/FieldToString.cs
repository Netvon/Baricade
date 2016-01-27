using Baricade.Core.Fields;

namespace Baricade.Client.Presentation
{
    class FieldToString
    {
        public static string Convert(BaseField field)
        {
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
