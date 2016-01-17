using Baricade.Core;
using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client.Presentation
{
    public class BoardView
    {
        public void ShowBoard(Board board)
        {
            
            Console.SetCursorPosition(5, 0);
            WriteTab();
            Console.WriteLine(ShowField(board.Finish));
            WriteTab();

            var field = board.Finish.GetField(Direction.Down);

            for(int i = 0; i < 4; i++)
            {
                field = field.GetField(Direction.Left);
            }

            Console.SetCursorPosition(1, 1);
            WriteTab();
            Console.Write(ShowField(field));
            for (int i = 0; i < 8; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(ShowField(field));               
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
            Console.Write(ShowField(field));
            for (int i = 0; i < 8; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(ShowField(field));              
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

            Console.Write(ShowField(field));
            for (int i = 0; i < 6; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(ShowField(field));
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
                     
            Console.Write(ShowField(field));
            for (int i = 0; i < 6; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(ShowField(field));
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
            Console.Write(ShowField(field));
            for (int i = 0; i < 4; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(ShowField(field));
            }

            Field forest = field.GetField(Direction.Left);
            for (int i = 0; i < 1; i++)
            {
                forest = forest.GetField(Direction.Left);
            }
            forest = forest.GetField(Direction.Down);

            Console.SetCursorPosition(3, 10);
            WriteTab();
            Console.Write("| " + ShowField(forest) + " |");

            Console.SetCursorPosition(3, 11);
            WriteTab();
            Console.Write("|   |");

            Console.SetCursorPosition(0, 14);
            WriteTab();
            field = board.Origin;

            Console.Write(ShowField(field));
            for(int i = 0; i < 10; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(ShowField(field));
            }

            Console.SetCursorPosition(0, 13);
            WriteTab();
            Console.WriteLine("| |  |  | |");

            field = board.Origin.GetField(Direction.Up);
            Console.SetCursorPosition(0, 12);
            WriteTab();
            Console.Write(ShowField(field));
            for (int i = 0; i < 10; i++)
            {
                field = field.GetField(Direction.Right);
                Console.Write(ShowField(field));
            }

            Console.SetCursorPosition(1, 15);
            WriteTab();
            Console.Write("| |   | |");

            field = board.Origin;
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);

            Console.SetCursorPosition(1, 16);
            WriteTab();
            Console.Write(ShowField(field));

            field = board.Origin;
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write(" " + ShowField(field));

            field = field.GetField(Direction.Up);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write("   " + ShowField(field));

            field = field.GetField(Direction.Up);
            field = field.GetField(Direction.Right);   
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write(" " + ShowField(field));
        }

        string ShowField(Field obj)
        {
            return FieldToString.Convert(obj);
            
        }

        private void WriteTab()
        {
            Console.Write("                      ");
        }
    }
}
