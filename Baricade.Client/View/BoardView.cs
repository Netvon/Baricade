using Baricade.Core;
using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.View
{
    public class BoardView
    {
        public void Show(Board board)
        {
            
            Console.SetCursorPosition(5, 0);
            WriteTab();
            Console.WriteLine(Show(board.Finish));
            WriteTab();

            var field = board.Finish.GetField(Direction.Down);

            for(int i = 0; i < 4; i++)
            {
                field = field.GetField(Direction.Left);
            }

            Console.SetCursorPosition(1, 1);
            WriteTab();
            Console.Write(Show(field));
            for (int i = 0; i < 8; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(Show(field));               
            }

            Console.SetCursorPosition(1, 2);
            WriteTab();
            Console.Write("|       |");

            field = field.GetField(Direction.Down);
            for(int i = 0; i < 8; i++)
            {
                field = field.GetField(Direction.Left);
            }

            Console.SetCursorPosition(1, 3);
            WriteTab();
            Console.Write(Show(field));
            for (int i = 0; i < 8; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(Show(field));              
            }

            Console.SetCursorPosition(5, 4);
            WriteTab();
            Console.Write("|");
            
            for (int i = 0; i < 4; i++)
            {
                field = field.GetField(Direction.Left);
            }
            field = field.GetField(Direction.Down);

            for(int i = 0; i < 3; i++)
            {
                field = field.GetField(Direction.Left);
            }

            Console.SetCursorPosition(2, 5);
            WriteTab();

            Console.Write(Show(field));
            for (int i = 0; i < 6; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(Show(field));
            }

            Console.SetCursorPosition(2, 6);
            WriteTab();
            Console.WriteLine("|     |");
            
            Console.SetCursorPosition(2, 7);
            WriteTab();
            field = field.GetField(Direction.Down);

            for (int i = 0; i < 6; i++)
            {
                field = field.GetField(Direction.Left);
            }
                     
            Console.Write(Show(field));
            for (int i = 0; i < 6; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(Show(field));
            }

            Console.SetCursorPosition(5, 8);
            WriteTab();
            Console.WriteLine("|");

            for (int i = 0; i < 3; i++)
            {
                field = field.GetField(Direction.Left);
            }
            field = field.GetField(Direction.Down);

            for (int i = 0; i< 3; i++)
            {
                field = field.GetField(Direction.Left);
            }

            Console.SetCursorPosition(3, 9);
            WriteTab();
            Console.Write(Show(field));
            for (int i = 0; i < 4; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(Show(field));
            }

            Field forest = field.GetField(Direction.Left); ;
            for (int i = 0; i < 1; i++)
            {
                forest = forest.GetField(Direction.Left);
            }
            forest = forest.GetField(Direction.Down);

            Console.SetCursorPosition(3, 10);
            WriteTab();
            Console.Write("| " + Show(forest) + " |");

            Console.SetCursorPosition(3, 11);
            WriteTab();
            Console.Write("|   |");

            Console.SetCursorPosition(0, 14);
            WriteTab();
            field = board.Origin;

            Console.Write(Show(field));
            for(int i = 0; i < 10; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(Show(field));
            }

            Console.SetCursorPosition(0, 13);
            WriteTab();
            Console.WriteLine("| |  |  | |");

            field = board.Origin.GetField(Direction.Up);
            Console.SetCursorPosition(0, 12);
            WriteTab();
            Console.Write(Show(field));
            for (int i = 0; i < 10; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(Show(field));
            }

            Console.SetCursorPosition(1, 15);
            WriteTab();
            Console.Write("| |   | |");

            field = board.Origin;
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);

            Console.SetCursorPosition(1, 16);
            WriteTab();
            Console.Write(Show(field));

            field = board.Origin;
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write(" " + Show(field));

            field = field.GetField(Direction.Up);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write("   " + Show(field));

            field = field.GetField(Direction.Up);
            field = field.GetField(Direction.Right);   
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write(" " + Show(field));
        }

        private String Show(Field obj)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            ContainerField item = obj as ContainerField;
            if(item != null)
            {
                if(item.Child is Baricade.Core.Movables.Baricade)
                {
                    return "B";
                }
            }         

            if (obj is FinishField)
            {
                return "*";
            }
            else if (obj is SpawnField)
            {
                var field = (SpawnField)obj;
                int color = field.Player.Number;
                Console.ForegroundColor = GetColor(color);

                
                return field.Children.Count()+"";
            }
            else if (obj is RestingField)
            {
                return "R";
            }
            else if (obj is ForestField)
            {
                return "F";
            }
            else
            {
                return "x";
            }
            
        }

        private ConsoleColor GetColor(int number)
        {
            switch (number)
            {
                case (1):
                    return ConsoleColor.Red;
                case (2):
                    return ConsoleColor.Green;
                case (3):
                    return ConsoleColor.Yellow;
                case (4):
                    return ConsoleColor.Blue;

                default:
                    return ConsoleColor.Magenta;
            }
        }

        private void WriteTab()
        {
            Console.Write(" ");
        }
    }
}
