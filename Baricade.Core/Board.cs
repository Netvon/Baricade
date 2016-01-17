using Baricade.Core.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core
{
    public class Board
    {
        public Board(Game game)
        {
            Width = 11;
            Height = 8;
            CreateBoard(game);
        }

        public Field Origin { get; private set; }
        public int Width { get; }
        public int Height { get; }

        void CreateBoard(Game game)
        {
            var origin = new BottomField();

            // Bottom Row
            Field first = CreateBottomRow(origin);

            // Spawn points
            CreateSpawnPoints(game, first);

            // Second Row
            Field second = CreateSecondRow(first);

            // Third Row
            Field third = CreateThridRow(second);

            // Fourth Row
            Field fourth = CreateFourthRow(third);

            // Fifth Row
            Field fifth = CreateFifthRow(fourth);

            // Sixth Row
            Field sixth = CreateSixthRow(fifth);

            // Seventh Row
            Field seventh = CreateSeventhRow(sixth);

            seventh.GetField(Direction.Right, 4)
                   .AddField(Direction.Up, new FinishField());

            Origin = origin;
        }

        Field CreateSeventhRow(Field sixth)
        {
            sixth.AddField(Direction.Up, new CityField());

            var seventh = sixth.GetField(Direction.Up);

            seventh.AddField(Direction.Right, 8, typeof(CityField));

            var b1 = seventh.GetField(Direction.Right, 4) as CityField;
            b1.Child = new Movables.Baricade();

            seventh.GetField(Direction.Right, 8)
                   .AddField(Direction.Down, sixth.GetField(Direction.Right, 8));

            return seventh;
        }

        Field CreateSixthRow(Field fifth)
        {
            var middle = fifth.GetField(Direction.Right, 3)
                 .AddField(Direction.Up, new CityField())
                 .GetField(Direction.Up);

            middle.AddField(Direction.Left, new RestingField());
            middle.GetField(Direction.Left)
                  .AddField(Direction.Left, 3, typeof(CityField));

            middle.AddField(Direction.Right, new RestingField());
            middle.GetField(Direction.Right)
                  .AddField(Direction.Right, 3, typeof(CityField));

            var sixth = middle.GetField(Direction.Left, 4);

            return sixth;
        }

        Field CreateFifthRow(Field fourth)
        {
            var fifth = fourth.AddField(Direction.Up, new CityField())
                  .GetField(Direction.Up);

            fifth.AddField(Direction.Right, 6, typeof(CityField));

            var b1 = fifth.GetField(Direction.Right, 2) as CityField;
            b1.Child = new Movables.Baricade();

            var b2 = fifth.GetField(Direction.Right, 4) as CityField;
            b2.Child = new Movables.Baricade();

            fourth.GetField(Direction.Right, 6)
                  .AddField(Direction.Up, fifth.GetField(Direction.Right, 6));

            return fifth;
        }

        Field CreateFourthRow(Field second)
        {
            var middle = second.GetField(Direction.Right, 3)
                  .AddField(Direction.Up)
                  .GetField(Direction.Up);

            middle.AddField(Direction.Left, 2);
            middle.AddField(Direction.Right, 2);

            middle.GetField(Direction.Left, 2)
                  .AddField(Direction.Left, new RestingField());

            middle.GetField(Direction.Right, 2)
                  .AddField(Direction.Right, new RestingField());

            var cf1 = middle.GetField(Direction.Right, 2) as ContainerField;
            cf1.Child = new Movables.Baricade();

            var cf2 = middle.GetField(Direction.Left, 2) as ContainerField;
            cf2.Child = new Movables.Baricade();

            return middle.GetField(Direction.Left, 3);

        }

        Field CreateThridRow(Field second)
        {
            var third = second.GetField(Direction.Right, 3)
                                          .AddField(Direction.Up)
                                          .GetField(Direction.Up);

            third.AddField(Direction.Right);

            third.GetField(Direction.Right)
                 .AddField(Direction.Right, new RestingField());

            third.GetField(Direction.Right, 2)
                 .AddField(Direction.Right, 2);

            third.GetField(Direction.Right, 2)
                 .AddField(Direction.Down, new ForestField());

            // Link Second & Third
            second.GetField(Direction.Right, 7)
                  .AddField(Direction.Up, third.GetField(Direction.Right, 4));

            return third;
        }

        Field CreateSecondRow(Field first)
        {
            var second = first.AddField(Direction.Up, new RestingField())
                                        .GetField(Direction.Up);

            second.AddField(Direction.Right);

            second.GetField(Direction.Right)
                  .AddField(Direction.Right, new RestingField());

            second.GetField(Direction.Right, 2)
                  .AddField(Direction.Right, 2);

            second.GetField(Direction.Right, 4)
                  .AddField(Direction.Right, new RestingField());

            second.GetField(Direction.Right, 5)
                  .AddField(Direction.Right, 2);

            second.GetField(Direction.Right, 7)
                  .AddField(Direction.Right, new RestingField());

            second.GetField(Direction.Right, 8)
                  .AddField(Direction.Right);

            second.GetField(Direction.Right, 9)
                  .AddField(Direction.Right, new RestingField());

            // Link First & Second
            first.GetField(Direction.Right, 2)
               .AddField(Direction.Up, second.GetField(Direction.Right, 2));

            first.GetField(Direction.Right, 5)
               .AddField(Direction.Up, second.GetField(Direction.Right, 5));

            first.GetField(Direction.Right, 8)
               .AddField(Direction.Up, second.GetField(Direction.Right, 8));

            first.GetField(Direction.Right, 10)
               .AddField(Direction.Up, second.GetField(Direction.Right, 10));

            return second;
        }

        void CreateSpawnPoints(Game game, Field first)
        {
            first.GetField(Direction.Right)
                           .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(0)));
            first.GetField(Direction.Right, 3)
               .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(1)));
            first.GetField(Direction.Right, 7)
               .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(2)));
            first.GetField(Direction.Right, 9)
               .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(3)));
        }

        Field CreateBottomRow(BottomField origin)
        {
            return origin.AddField(Direction.Right, 10, typeof(BottomField));
        }
    }
}
