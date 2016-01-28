using Baricade.Client;
using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.Controller
{
    class InputController
    {
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

        public int GetPawnNumber()
        {
            int input = 0;
            bool isCorrect = false;
            while (!isCorrect)
            {
                int.TryParse(Console.ReadLine(), out input);
                if (input > 0 && input <= 4)
                {
                    isCorrect = true;
                }
            }
            return input;
        }
    }

    class KeyInputResult<T>
    {
        public KeyInputResult(T result, ConsoleKeyInfo key)
        {
            Key = key;
            Result = result;
        }

        public KeyInputResult(ConsoleKeyInfo key)
        {
            Key = key;
        }

        public T Result { get; }
        public ConsoleKeyInfo Key { get; }
    }
}
