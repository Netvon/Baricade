using Baricade.Client.Presentation;
using Baricade.Core;
using Baricade.Core.Fields;
using Baricade.Core.Movables;
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
            Show(board.Finish);
            WriteTab();

            var field = board.Finish.GetField(Direction.Down);

            //for(int i = 0; i < 4; i++)
            //{
                field = field.GetField(Direction.Left, 4);
            //}

            Console.SetCursorPosition(1, 1);
            WriteTab();
            Show(field);
            for (int i = 0; i < 8; i++)
            {
                field = field.GetField(Direction.Right);
                Show(field);               
            }

            Console.SetCursorPosition(1, 2);
            WriteTab();
            
            Console.Write("|       |");

            field = field.GetField(Direction.Down);
            //for(int i = 0; i < 8; i++)
            //{
                field = field.GetField(Direction.Left, 8);
            //}

            Console.SetCursorPosition(1, 3);
            WriteTab();
            Show(field);
            for (int i = 0; i < 8; i++)
            {
                field = field.GetField(Direction.Right);
                Show(field);              
            }

            Console.SetCursorPosition(5, 4);
            WriteTab();
            
            Console.Write("|");
            
            //for (int i = 0; i < 4; i++)
            //{
                field = field.GetField(Direction.Left, 4);
            //}
            field = field.GetField(Direction.Down);

            //for(int i = 0; i < 3; i++)
            //{
                field = field.GetField(Direction.Left, 3);
            //}

            Console.SetCursorPosition(2, 5);
            WriteTab();

            Show(field);
            for (int i = 0; i < 6; i++)
            {
                field = field.GetField(Direction.Right);
                Show(field);
            }

            Console.SetCursorPosition(2, 6);
            WriteTab();
            
            Console.WriteLine("|     |");
            
            Console.SetCursorPosition(2, 7);
            WriteTab();
            field = field.GetField(Direction.Down);

            //for (int i = 0; i < 6; i++)
            //{
                field = field.GetField(Direction.Left, 6);
            //}
                     
            Show(field);
            for (int i = 0; i < 6; i++)
            {
                field = field.GetField(Direction.Right);
                Show(field);
            }

            Console.SetCursorPosition(5, 8);
            WriteTab();
            
            Console.WriteLine("|");

            //for (int i = 0; i < 3; i++)
            //{
                field = field.GetField(Direction.Left, 3);
            //}
            field = field.GetField(Direction.Down);

            //for (int i = 0; i< 3; i++)
            //{
                field = field.GetField(Direction.Left, 2);
            //}

            Console.SetCursorPosition(3, 9);
            WriteTab();
            Show(field);
            for (int i = 0; i < 4; i++)
            {
                field = field.GetField(Direction.Right);
                Show(field);
            }

            BaseField forest = field.GetField(Direction.Left);
            //for (int i = 0; i < 1; i++)
            //{
                forest = forest.GetField(Direction.Left);
            //}
            forest = forest.GetField(Direction.Down);

            Console.SetCursorPosition(3, 10);
            WriteTab();
            
            Console.Write("| ");
            Show(forest);
            Console.Write(" |");

            Console.SetCursorPosition(3, 11);
            WriteTab();
            
            Console.Write("|   |");

            Console.SetCursorPosition(0, 14);
            WriteTab();
            field = board.Origin;

            Show(field);
            for(int i = 0; i < 10; i++)
            {
                field = field.GetField(Direction.Right);
                Show(field);
            }

            Console.SetCursorPosition(0, 13);
            WriteTab();
           
            Console.WriteLine("| |  |  | |");

            field = board.Origin.GetField(Direction.Up);
            Console.SetCursorPosition(0, 12);
            WriteTab();
            Show(field);
            for (int i = 0; i < 10; i++)
            {
                field = field.GetField(Direction.Right);
                Show(field);
            }

            Console.SetCursorPosition(1, 15);
            WriteTab();
            
            Console.Write("| |   | |");

            field = board.Origin;
            field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);

            Console.SetCursorPosition(1, 16);
            WriteTab();
            Show(field);

            field = board.Origin;
            field = field.GetField(Direction.Right, 3);
            //field = field.GetField(Direction.Right);
            //field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write(" ");
            Show(field);

            field = field.GetField(Direction.Up);
            field = field.GetField(Direction.Right, 4);
            //field = field.GetField(Direction.Right);
            //field = field.GetField(Direction.Right);
            //field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write("   ");
            Show(field);

            field = field.GetField(Direction.Up);
            field = field.GetField(Direction.Right, 2);   
            //field = field.GetField(Direction.Right);
            field = field.GetField(Direction.Down);
            Console.Write(" ");
            Show(field);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
            ShowForest(board);
        }

        void ShowForest(Board board)
        {
            Console.Write("--------------");
            foreach(var child in board.Forest.Children)
            {
                Console.Write("---");
            }
            Console.Write("\n");
            Console.Write("Forest bevat: ");
            foreach(var child in board.Forest.Children)
            {
                var pawn = child as Pawn;
                Console.ForegroundColor = FieldToColors.GetPawnColor(pawn.Owner.Number).Foreground;
                Console.Write(pawn.Number);
                Console.ForegroundColor = Colors.DefaultForeground;
                Console.Write(", ");
            }
            Console.ForegroundColor = Colors.DefaultForeground;
            Console.Write("| \n");
            Console.Write("--------------");
            foreach (var child in board.Forest.Children)
            {
                Console.Write("---");
            }
            Console.Write("\n");
        }

        void Show(BaseField obj)
        {
            Colors colors = FieldToColors.Convert(obj);
            Console.BackgroundColor = colors.Background;
            Console.ForegroundColor = colors.Foreground;

            Console.Write(FieldToString.Convert(obj));

            Console.BackgroundColor = Colors.DefaultBackground;
            Console.ForegroundColor = Colors.DefaultForeground;
        }

        private void WriteTab()
        {
            //Console.Write("                     ");
        }
    }
}
