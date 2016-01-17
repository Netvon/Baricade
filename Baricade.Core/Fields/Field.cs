using Baricade.Core.Movables;
using Baricade.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    public abstract class Field
    {
        Dictionary<Direction, Field> _fieldDictionary;

        public Field()
        {
            _fieldDictionary = new Dictionary<Direction, Field>();

            _fieldDictionary.Add(Direction.Up, null);
            _fieldDictionary.Add(Direction.Down, null);
            _fieldDictionary.Add(Direction.Left, null);
            _fieldDictionary.Add(Direction.Right, null);

            UniqueID = Guid.NewGuid();
        }

        public Field(Field sendToAfterHit)
            :this()
        {
            SendToAfterHit = sendToAfterHit;
        }

        public Guid UniqueID { get; }
        public virtual bool IsEmpty => true;        

        public static Field DefaultField => new ContainerField();
        public Field SendToAfterHit { get; set; }

        public Field AddField(Field field, Direction location)
        {
            _fieldDictionary[location] = field;

            if (field.GetField(location.Opposite()) == null)
                field.AddField(this, location.Opposite());
            
            return this;
        }

        public Field AddField(Direction location)
        {
            return AddField(DefaultField, location);
        }

        public Field AddField(Direction location, int count)
        {
            Field newField = this;
            for (int i = 0; i < count; i++)
            {
                var tempNewField = DefaultField;
                newField.AddField(tempNewField, location);

                newField = tempNewField;
            }
            return this;
        }

        public Field GetField(Direction location)
        {
            return _fieldDictionary[location];
        }

        public Field GetField(Direction location, int count)
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

        public abstract bool AcceptMovable(Movable movable);
    }
}
