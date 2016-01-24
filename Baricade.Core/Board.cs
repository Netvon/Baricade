using Baricade.Core.Fields;
using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core
{
    public class Board
    {
        Dictionary<Player, CollectionField> _spawnPoints;
        CollectionField _forestField;

        public Board(Game game)
        {
            _spawnPoints = new Dictionary<Player, CollectionField>();

            CreateBoard(game);
        }

        public CollectionField Forest => _forestField;
        public BaseField Origin { get; private set; }
        public BaseField Finish { get; private set; }

        void CreateBoard(Game game)
        {
            var origin = new BottomField();
            origin.Row = 1;
            origin.Column = 0;

            // Bottom Row
            BaseField first = CreateBottomRow(origin);

            // Spawn points
            CreateSpawnPoints(game, first);

            // Second Row
            BaseField second = CreateSecondRow(first);

            // Third Row
            BaseField third = CreateThridRow(second);

            // Fourth Row
            BaseField fourth = CreateFourthRow(third);

            // Fifth Row
            BaseField fifth = CreateFifthRow(fourth);

            // Sixth Row
            BaseField sixth = CreateSixthRow(fifth);

            // Seventh Row
            BaseField seventh = CreateSeventhRow(sixth);

            Finish = seventh.GetField(Direction.Right, 4)
                   .AddField(Direction.Up, new FinishField()).GetField(Direction.Up);

            Origin = origin;
        }

        BaseField CreateSeventhRow(BaseField sixth)
        {
            sixth.AddField(Direction.Up, new CityField());

            var seventh = sixth.GetField(Direction.Up);

            seventh.AddField(Direction.Right, 8, typeof(CityField));

            var b1 = seventh.GetField(Direction.Right, 4) as CityField;
            AddBaricade(b1);            

            seventh.GetField(Direction.Right, 8)
                   .AddField(Direction.Down, sixth.GetField(Direction.Right, 8));

            return seventh;
        }

        BaseField CreateSixthRow(BaseField fifth)
        {
            var middle = fifth.GetField(Direction.Right, 3)
                 .AddField(Direction.Up, new CityField())
                 .GetField(Direction.Up);

            var mid = middle as CityField;
            AddBaricade(mid);

            middle.AddField(Direction.Left, new RestingField());
            middle.GetField(Direction.Left)
                  .AddField(Direction.Left, 3, typeof(CityField));

            middle.AddField(Direction.Right, new RestingField());
            middle.GetField(Direction.Right)
                  .AddField(Direction.Right, 3, typeof(CityField));

            var sixth = middle.GetField(Direction.Left, 4);

            return sixth;
        }

        BaseField CreateFifthRow(BaseField fourth)
        {
            var fifth = fourth.AddField(Direction.Up, new CityField())
                  .GetField(Direction.Up);

            fifth.AddField(Direction.Right, 6, typeof(CityField));

            var b1 = fifth.GetField(Direction.Right, 2) as CityField;
            AddBaricade(b1);

            var b2 = fifth.GetField(Direction.Right, 4) as CityField;
            AddBaricade(b2);

            fourth.GetField(Direction.Right, 6)
                  .AddField(Direction.Up, fifth.GetField(Direction.Right, 6));

            return fifth;
        }

        BaseField CreateFourthRow(BaseField third)
        {
            var middleOfFourth = third.GetField(Direction.Right, 2)
                  .AddField(Direction.Up)
                  .GetField(Direction.Up);

            middleOfFourth.AddField(Direction.Left, 2);
            middleOfFourth.AddField(Direction.Right, 2);

            middleOfFourth.GetField(Direction.Left, 2)
                  .AddField(Direction.Left, new RestingField());

            middleOfFourth.GetField(Direction.Right, 2)
                  .AddField(Direction.Right, new RestingField());

            var cf1 = middleOfFourth.GetField(Direction.Right, 2) as ContainerField;
            AddBaricade(cf1);

            var cf2 = middleOfFourth.GetField(Direction.Left, 2) as ContainerField;
            AddBaricade(cf2);

            //var middleOfThird = third.GetField(Direction.Right, 2);

            //third.GetField(Direction.Right, 2)
            //     .AddField(Direction.Up, middle);

            var forth = middleOfFourth.GetField(Direction.Left, 3);
            return forth;

        }

        BaseField CreateThridRow(BaseField second)
        {
            var third = second.GetField(Direction.Right, 3)
                            .AddField(Direction.Up)
                            .GetField(Direction.Up);

            third.AddField(Direction.Right);

            third.GetField(Direction.Right)
                 .AddField(Direction.Right, new RestingField());

            third.GetField(Direction.Right, 2)
                 .AddField(Direction.Right, 2);

            _forestField = new ForestField();

            third.GetField(Direction.Right, 2)
                 .AddField(Direction.Down, _forestField);


            // Link Second & Third
            second.GetField(Direction.Right, 7)
                  .AddField(Direction.Up, third.GetField(Direction.Right, 4));

            return third;
        }

        BaseField CreateSecondRow(BaseField first)
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

        void CreateSpawnPoints(Game game, BaseField first)
        {
            var sp1 = first.GetField(Direction.Right)
                 .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(0)))
                 .GetField(Direction.Down);

            var sp2 = first.GetField(Direction.Right, 3)
               .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(1)))
               .GetField(Direction.Down);

            var sp3 = first.GetField(Direction.Right, 7)
               .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(2)))
               .GetField(Direction.Down);

            var sp4 = first.GetField(Direction.Right, 9)
               .AddField(Direction.Down, new SpawnField(game.Players.ElementAt(3)))
               .GetField(Direction.Down);

            _spawnPoints.Add(game.Players.ElementAt(0), sp1 as CollectionField);
            _spawnPoints.Add(game.Players.ElementAt(1), sp2 as CollectionField);
            _spawnPoints.Add(game.Players.ElementAt(2), sp3 as CollectionField);
            _spawnPoints.Add(game.Players.ElementAt(3), sp4 as CollectionField);
        }

        BaseField CreateBottomRow(BottomField origin)
        {
            return origin.AddField(Direction.Right, 10, typeof(BottomField));
        }

        void AddBaricade(ContainerField b1)
        {
#if !NOBARICADE
            b1.Child = new Movables.Baricade();
            b1.Child.StandingOn = b1;
#endif
        }

        internal CollectionField GetSpawnPointForPlayer(Player player)
        {
            return _spawnPoints[player];
        }
    }
}
