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
        private readonly Game _game;

        private readonly BoardView _boardview;
        private readonly GameView _gameview;

        private readonly InputController _inputController;

        public GameController()
        {
            _game = Game.Current;

            _boardview = new BoardView();
            _gameview = new GameView();

            _inputController = new InputController();
        }

        public void PlayGame()
        {
            _game.StartGame();
            _boardview.Show(_game.Board);
            while (!_game.IsWon)
            {
                while(_game.IsBaricadeMoveModeActive)
                {                    
                    _gameview.ShowBaricade(_game.BaricadeCursor);

                    var direction = _inputController.GetDirection();

                    if(direction.Key.Key == ConsoleKey.Enter)
                    {
                        _game.TryPlaceBaricade();
                    }
                    else 
                    {
                        _game.TryMoveBaricadeCursor(direction.Result);
                    }
                    RefreshBoard();
                }

                int number = _game.Dice.LastValue;

                _gameview.ShowTurn(_game.CurrentPlayer.Number, number);
                int pawn = _inputController.GetPawnNumber();
                _game.SelectPawnForMove(pawn);
                
                RefreshBoard();

                int i = 0;
                while (i < number)
                {                    
                    _gameview.ShowMove(number - i);

                    var direction = _inputController.GetDirection();

                    if (direction.Key.Key == ConsoleKey.R)
                    {
                        i = 0;
                        _game.CurrentPawn.ResetMove();
                        RefreshBoard();
                        break;
                    }

                    if (direction.Result == Direction.None)
                    {
                        RefreshBoard();
                        _gameview.WrongMove();
                        continue;
                    }

                    if (_game.TryMove(direction.Result))
                    {
                        i++;
                        RefreshBoard();
                    }
                    else
                    {
                        RefreshBoard();
                        _gameview.WrongMove();
                    }
                    
                }                
                RefreshBoard();
            }
            _gameview.ShowWinner(_game.Board.Finish.Child.Owner);
            Console.ReadKey();       
        }

        private void RefreshBoard()
        {
            Console.Clear();
            _boardview.Show(_game.Board);
        }
        
    }
}
