using Baricade.Client.View;
using Baricade.Core;
using Baricade.Core.Fields;
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
            game = Game.GetInstance();

            boardview = new BoardView();

            //bv.Show(game.Board);

            gameview = new GameView();

            //gv.ShowTurn(game.CurrentPlayer.Number);

            //Console.ReadLine();
        }

        public void PlayGame()
        {
            boardview.Show(game.Board);
            int pawn = gameview.ShowTurn(game.CurrentPlayer.Number);
            game.SelectPawnForMove(pawn);

            int number = game.Dice.Roll();

            gameview.Move(number);

            int i = 0;
            while(i < number)
            {
                String directionString = gameview.GetDirection();
                var direction = Enum.Parse(typeof(Direction), directionString);

                if(game.TryMove((Direction)direction))
                {
                    i++;
                    ClearBoard();
                }
                else
                {
                    gameview.WrongMove();
                }               
            }
            Console.ReadLine();
        }

        private void ClearBoard()
        {
            Console.Clear();
            boardview.Show(game.Board);
        }
        
    }
}
