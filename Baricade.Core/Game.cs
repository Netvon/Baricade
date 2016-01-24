using Baricade.Core.Fields;
using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core
{
    public class Game
    {
        static Game _instance;
        int _currentPlayer;
        int _currentPawn;

        Game(Dice dice, params Player[] players)
        {
            Players = players;
            Board = new Board(this);

            foreach (var p in Players)
                p.Game = this;

            Dice = dice;
        }

        public IEnumerable<Player> Players { get; }
        public Board Board { get; }
        public Dice Dice { get; }

        public BaseField BaricadeCursor { get; internal set; }
        public Movable MovingBaricade { get; internal set; }

        public bool IsWon { get; internal set; }

        public Player CurrentPlayer => Players.ElementAt(_currentPlayer);
        public Movable CurrentPawn => CurrentPlayer.Pawns.FirstOrDefault(p => p.Number == _currentPawn);

        public bool IsBaricadeMoveModeActive { get; internal set; }

        public void StartGame()
        {
            _currentPlayer = 0;

            Dice.Roll();
        }

        public void SelectPawnForMove(int pawnNumber)
        {
            if (pawnNumber > 0 && pawnNumber <= 4)
            {
                _currentPawn = pawnNumber;
                CurrentPawn.StartMove(Dice.LastValue);
            }
        }

        internal void SetBaricadeMoveMode(Movable baricade)
        {
            MovingBaricade = baricade;
            SetBaricadeCursor(baricade.StandingOn);
            IsBaricadeMoveModeActive = true;
        }

        public bool TryMove(Direction direction)
        {
            var canMove = CurrentPawn.Move(direction);

            if (CurrentPawn.AvailableMoves == 0 && !IsBaricadeMoveModeActive)
                NextTurn();

            return canMove;
        }

        public void NextTurn()
        {
            _currentPlayer++;
            _currentPlayer %= Players.Count();

            Dice.Roll();
        }

        public void SetBaricadeCursor(BaseField field)
        {
            BaricadeCursor = field;
        }

        public void SetWin()
        {
            IsWon = true;
        }

        public bool TryMoveBaricadeCursor(Direction direction)
        {
            var target = BaricadeCursor.GetField(direction);

            if (target == null)
                return false;

            BaricadeCursor = target;
            return true;
        }

        public bool TryPlaceBaricade()
        {
            var canPlace = BaricadeCursor.AcceptMove(MovingBaricade);

            if(canPlace)
            {
                var newBaricadeField = BaricadeCursor as ContainerField;
                newBaricadeField.Child = MovingBaricade;

                MovingBaricade = null;
                IsBaricadeMoveModeActive = false;
                BaricadeCursor = null;

                NextTurn();
            }

            return canPlace;
        }

        public static Game Current
        {
            get
            {
                if (_instance == null)
                    _instance = new Game(new Dice(6),
                        new Player(1), new Player(2), new Player(3), new Player(4));

                return _instance;
            }
        }
    }
}
