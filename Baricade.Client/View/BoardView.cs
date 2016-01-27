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

        }

        void Show(BaseField obj)
        {
            ContainerField item = obj as ContainerField;

            if (obj == Game.Current.BaricadeCursor)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(MovableToString.Convert(item.TempChild));
            }
            
            else if(item != null)
            {
                
                if(item.Child is Pawn || item.TempChild is Pawn)
                {
                    Pawn pawn;
                    if (item.TempChild != null)
                    {
                        pawn = item.TempChild as Pawn;
                    }
                    else
                    {
                        pawn = item.Child as Pawn;
                    }
                    Console.ForegroundColor = GetColor(pawn.Owner.Number);
                    
                    Console.Write(pawn.Number);
                }
                else if (item.Child is Baricade.Core.Movables.Baricade)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(MovableToString.Convert(item.Child));
                }
                else
                {
                    Console.Write(FieldToString.Convert(obj));
                }
            }
            else if (obj is SpawnField)
            {
                var field = (SpawnField)obj;
                int color = field.Player.Number;
                Console.ForegroundColor = GetColor(color);
                Console.Write(field.Children.Count);
            }
            
            else
            {
                Console.Write(FieldToString.Convert(obj));
            }                

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
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
            //Console.Write("                     ");
        }
    }
}
