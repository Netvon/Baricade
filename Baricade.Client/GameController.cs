using Baricade.Client.View;
using Baricade.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Client
{
    public class GameController
    {
        private readonly Game game;

        private readonly BoardView boardview;
        private readonly GameView gameview;

        public GameController()
        {
            game = new Game(new Player(1), new Player(2), new Player(3), new Player(4));

            boardview = new BoardView();

            //bv.Show(game.Board);

            gameview = new GameView();

            //gv.ShowTurn(game.CurrentPlayer.Number);

            //Console.ReadLine();
        }

        public void PlayGame()
        {
            
        }
    }
}
