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
            Game game = Game.GetInstance();            

            BoardView bv = new BoardView();

            bv.Show(game.Board);
            Console.ReadLine();
        }
    }
}
