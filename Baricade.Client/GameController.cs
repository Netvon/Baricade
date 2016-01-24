using Baricade.Client.Presentation;
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
            game = Game.Current;

            boardview = new BoardView();

            //bv.Show(game.Board);

            gameview = new GameView();

            //gv.ShowTurn(game.CurrentPlayer.Number);

            //Console.ReadLine();
        }

        public void PlayGame()
        {
            game.StartGame();
            boardview.Show(game.Board);
            while (!game.IsWon)
            {
                while(game.IsBaricadeMoveModeActive)
                {
                    //RefreshBoard();

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Herplaats de Baricade");

                    InputController inputController = new InputController();

                    var direction = inputController.GetDirection();

                    if(direction.Key.Key == ConsoleKey.Enter)
                    {
                        game.TryPlaceBaricade();
                    }
                    else 
                    {
                        game.TryMoveBaricadeCursor(direction.Result);
                    }
                    RefreshBoard();
                }

                int pawn = gameview.ShowTurn(game.CurrentPlayer.Number);
                game.SelectPawnForMove(pawn);
                
                int number = game.Dice.LastValue;

                RefreshBoard();

                int i = 0;
                while (i < number)
                {
                    
                    gameview.Move(number - i);

                    //string directionString = gameview.GetDirection();

                    //if(directionString == "reset")
                    //{
                    //    i = 0;
                    //    game.CurrentPawn.ResetMove();
                    //    RefreshBoard();
                    //    break;
                    //}

                    InputController inputController = new InputController();

                    var direction = inputController.GetDirection();//Enum.Parse(typeof(Direction), directionString, true);

                    if (direction.Key.Key == ConsoleKey.R)
                    {
                        i = 0;
                        game.CurrentPawn.ResetMove();
                        RefreshBoard();
                        break;
                    }

                    if (direction.Result == Direction.None)
                    {
                        RefreshBoard();
                        gameview.WrongMove();
                        continue;
                    }

                    if (game.TryMove(direction.Result))
                    {
                        i++;
                        RefreshBoard();
                    }
                    else
                    {
                        RefreshBoard();
                        gameview.WrongMove();
                    }
                    
                }
                
                RefreshBoard();
            }       
        }

        private void RefreshBoard()
        {
            Console.Clear();
            boardview.Show(game.Board);
        }
        
    }
}
