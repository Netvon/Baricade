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
            game.StartGame();
            boardview.Show(game.Board);
            while (!game.IsWon)
            {
                while(game.IsBaricadeMoveModeActive)
                {
                    RefreshBoard();

                    Console.WriteLine("Herplaats de Baricade");

                    var dir = gameview.GetDirection();

                    var direction = Enum.Parse(typeof(Direction), dir, true);

                    if(game.TryMoveBaricadeCursor((Direction)direction))
                    {
                        Console.WriteLine("Wil je de baricade plaatsen? (ja/nee)");
                        var place = Console.ReadLine();
                        if (place.ToLower() == "ja")
                            game.TryPlaceBaricade();
                    }
                }

                int pawn = gameview.ShowTurn(game.CurrentPlayer.Number);
                game.SelectPawnForMove(pawn);
                
                int number = game.Dice.LastValue;

                RefreshBoard();

                int i = 0;
                while (i < number)
                {
                    
                    gameview.Move(number - i); 

                    string directionString = gameview.GetDirection();

                    if(directionString == "reset")
                    {
                        i = 0;
                        game.CurrentPawn.ResetMove();
                        RefreshBoard();
                        break;
                    }

                    var direction = Enum.Parse(typeof(Direction), directionString, true);

                    if (game.TryMove((Direction)direction))
                    {
                        i++;
                        RefreshBoard();
                    }
                    else
                    {
                        RefreshBoard();
                        gameview.WrongMove();
                    }
                    
                    
                    game.CurrentPawn.EndMove();
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
