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

            var origin = Field.DefaultField;

            // Bottom Row
            var top = origin.AddField(Direction.Right, 10);

            // Spawn points
            top.GetField(Direction.Right)
               .AddField(new SpawnField(game.Players.ElementAt(0)), Direction.Up);
            top.GetField(Direction.Right, 3)
               .AddField(new SpawnField(game.Players.ElementAt(1)), Direction.Up);
            top.GetField(Direction.Right, 7)
               .AddField(new SpawnField(game.Players.ElementAt(2)), Direction.Up);
            top.GetField(Direction.Right, 9)
               .AddField(new SpawnField(game.Players.ElementAt(3)), Direction.Up);

            // Second Row
            var second = top.AddField(Direction.Down)
                            .GetField(Direction.Down);

            second.AddField(Direction.Right, 10);

            top.GetField(Direction.Right, 2)
               .AddField(second.GetField(Direction.Right, 2), Direction.Down);

            top.GetField(Direction.Right, 5)
               .AddField(second.GetField(Direction.Right, 5), Direction.Down);

            top.GetField(Direction.Right, 8)
               .AddField(second.GetField(Direction.Right, 8), Direction.Down);

            top.GetField(Direction.Right, 10)
               .AddField(second.GetField(Direction.Right, 10), Direction.Down);

            Origin = origin;
        }

        public Field Origin { get; }
        public int Width { get; }
        public int Height { get; }
    }
}
