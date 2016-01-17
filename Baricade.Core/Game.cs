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

        Game(params Player[] players)
        {
            Players = players;
            Board = new Board(this);

            foreach (var p in Players)
                p.Game = this;

            Dice = new Dice(6);
        }

        public IEnumerable<Player> Players { get; }
        public Board Board { get; }
        public Dice Dice { get; }

        public Field BaricadeCursor { get; internal set; }
        public Movable MovingBaricade { get; internal set; }

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

        public void SetBaricadeCursor(Field field)
        {
            BaricadeCursor = field;
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
            var canPlace = BaricadeCursor.AcceptMovable(MovingBaricade);

            if(canPlace)
            {
                MovingBaricade = null;
                IsBaricadeMoveModeActive = false;
                BaricadeCursor = null;

                NextTurn();
            }

            return canPlace;
        }

        public static Game GetInstance()
        {
            if (_instance == null)
                _instance = new Game(new Player(1), new Player(2), new Player(3), new Player(4));

            return _instance;
        }
    }
}
