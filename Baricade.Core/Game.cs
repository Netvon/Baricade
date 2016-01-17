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
        int _currentPlayer;
        int _currentPawn;

        public Game(params Player[] players)
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

        public Player CurrentPlayer => Players.ElementAt(_currentPlayer);
        public Movable CurrentPawn => CurrentPlayer.Pawns.FirstOrDefault(p => p.Number == _currentPawn);

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

        public bool TryMove(Direction direction)
        {
            var canMove = CurrentPawn.Move(direction);

            if (CurrentPawn.AvailableMoves == 0)
                NextTurn();

            return canMove;
        }

        public void NextTurn()
        {
            _currentPlayer++;
            _currentPlayer %= Players.Count();

            Dice.Roll();
        }
    }
}
