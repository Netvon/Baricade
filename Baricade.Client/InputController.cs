using Baricade.Client;
using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client
{
    class InputController
    {
        public InputResult<int?> GetInteger(int min, int max)
        {
            var input = Console.ReadLine();

            int number;
            bool isValidNumber = int.TryParse(input, out number);

            if (isValidNumber && number >= min && number <= max)
                return new InputResult<int?>(number, input);

            return new InputResult<int?>(null, input);
        }

        public KeyInputResult<Direction> GetDirection()
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    return new KeyInputResult<Direction>(Direction.Left, key);
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    return new KeyInputResult<Direction>(Direction.Right, key);
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    return new KeyInputResult<Direction>(Direction.Up, key);
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    return new KeyInputResult<Direction>(Direction.Down, key);
            }

            return new KeyInputResult<Direction>(key);
        }
    }

    class InputResult<T>
    {
        public InputResult(T result, string input)
        {
            Result = result;
            Input = input;
        }

        public T Result { get; }
        public string Input { get; }
        public bool IsResultNull => Result == null;
    }

    class KeyInputResult<T> : InputResult<T>
    {
        public KeyInputResult(T result, ConsoleKeyInfo key)
            : base(result, key.ToString())
        {
            Key = key;
        }

        public KeyInputResult(ConsoleKeyInfo key)
            :base(default(T), key.ToString())
        {
            Key = key;
        }

        public ConsoleKeyInfo Key { get; }
    }
}
