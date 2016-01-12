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
            Field current = board.Origin;

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    if(current == null)
                    {
                        Console.Write(' ');
                        continue;
                    }

                    current = current.GetField(Direction.Right);
                }

                Console.WriteLine();
            }
        }
    }
}
