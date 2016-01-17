using Baricade.Client.View;
using Baricade.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var finish = Field.EmptyField;

            //finish.AddField(FieldLocation.Down)
            //      .GetField(FieldLocation.Down)
            //      .AddField(FieldLocation.Left, 4)
            //      .AddField(FieldLocation.Right, 4);

            //var farLeft = finish.GetField(FieldLocation.Down)
            //                    .GetField(FieldLocation.Left, 4);

            //finish.GetField(FieldLocation.Down)
            //      .GetField(FieldLocation.Right, 4)
            //      .AddField(FieldLocation.Down)
            //      .GetField(FieldLocation.Down)
            //      .AddField(FieldLocation.Left, 8)
            //      .GetField(FieldLocation.Left, 8)
            //      .AddField(farLeft, FieldLocation.Up);

            //var endOfVillage = finish.GetField(FieldLocation.Down)
            //      .GetField(FieldLocation.Left, 4)
            //      .GetField(FieldLocation.Down)
            //      .GetField(FieldLocation.Right, 4);

            //endOfVillage.AddField(FieldLocation.Down)
            //    .GetField(FieldLocation.Down)
            //    .AddField(FieldLocation.Left, 3)
            //    .AddField(FieldLocation.Right, 3);


            //var origin = Field.EmptyField;

            //// Bottom Row
            //var top = origin.AddField(Direction.Right, 10);

            //// Second Row
            //var second = top.AddField(Direction.Down)
            //                   .GetField(Direction.Down);

            //second.AddField(Direction.Right, 10);

            //top.GetField(Direction.Right, 2)
            //   .AddField(second.GetField(Direction.Right, 2), Direction.Down);

            //top.GetField(Direction.Right, 5)
            //   .AddField(second.GetField(Direction.Right, 5), Direction.Down);

            //top.GetField(Direction.Right, 8)
            //   .AddField(second.GetField(Direction.Right, 8), Direction.Down);

            //top.GetField(Direction.Right, 10)
            //   .AddField(second.GetField(Direction.Right, 10), Direction.Down);

            Game game = new Game(new Player(1), new Player(2), new Player(3), new Player(4));
            

            BoardView bv = new BoardView();
            bv.Show(game.Board);
            Console.ReadLine();
        }
    }
}
