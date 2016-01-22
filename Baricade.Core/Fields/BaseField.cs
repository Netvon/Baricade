using Baricade.Core.Movables;
using Baricade.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    public abstract class BaseField
    {
        Dictionary<Direction, BaseField> _fieldDictionary;

        public BaseField()
        {
            _fieldDictionary = new Dictionary<Direction, BaseField>();

            _fieldDictionary.Add(Direction.Up, null);
            _fieldDictionary.Add(Direction.Down, null);
            _fieldDictionary.Add(Direction.Left, null);
            _fieldDictionary.Add(Direction.Right, null);

            UniqueID = Guid.NewGuid();
        }

        public Board Board => Game.Current.Board;
        public Guid UniqueID { get; }
        public virtual bool IsEmpty => true;        

        public static BaseField DefaultField => new ContainerField();

        public BaseField AddField(Direction location, BaseField field)
        {
            _fieldDictionary[location] = field;

            if (field.GetField(location.Opposite()) == null)
                field.AddField(location.Opposite(), this);
            
            return this;
        }

        public BaseField AddField(Direction location)
        {
            return AddField(location, DefaultField);
        }

        public BaseField AddField(Direction location, int count)
        {
            return AddField(location, count, typeof(ContainerField));
        }

        public BaseField AddField(Direction location, int count, Type fieldType)
        {
            BaseField newField = this;
            for (int i = 0; i < count; i++)
            {      
                BaseField tempNewField = Activator.CreateInstance(fieldType) as BaseField;
                newField.AddField(location, tempNewField);

                newField = tempNewField;
            }
            return this;
        }

        public BaseField GetField(Direction location)
        {
            return _fieldDictionary[location];
        }

        public BaseField GetField(Direction location, int count)
        {
            var current = this;
            for (int i = 0; i < count; i++)
            {
                current = current.GetField(location);
            }

            return current;
        }

        public bool HasFieldInDirection(Direction location)
        {
            return GetField(location) != null;
        }

        public abstract bool AcceptMove(Movable movable);
    }
}
