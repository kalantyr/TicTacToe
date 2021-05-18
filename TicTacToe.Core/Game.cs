using System;
using System.Collections.Generic;

namespace TicTacToe.Core
{
    public class Game : IGame
    {
        /// <summary>
        /// Размер стороны по умолчанию
        /// </summary>
        public const byte DefaultSize = 3;

        private readonly List<GameMove> _gameMoves = new List<GameMove>();
        private State?[,] _currentState;

        /// <inheritdoc/>
        public State?[,] CurrentState
        {
            get
            {
                //var currentState = new State?[Size, Size];
                //foreach (var move in _gameMoves)
                //    currentState[move.X, move.Y] = move.State;
                return _currentState;
            }
        }

        /// <inheritdoc/>
        public byte Size { get; }

        /// <inheritdoc/>
        public event Action<GameMove> OnMove;

        /// <inheritdoc/>
        public event Action<Player?> End;

        /// <inheritdoc/>
        public bool IsGameOver { get; private set; }

        /// <inheritdoc/>
        public Player? Winner { get; private set; }

        /// <inheritdoc/>
        public IReadOnlyCollection<GameMove> Moves => _gameMoves;

        public Game(byte size = DefaultSize)
        {
            Size = size;
        }

        /// <inheritdoc/>
        public IGame Clone()
        {
            var clone = new Game(Size)
            {
                IsGameOver = IsGameOver,
                Winner = Winner
            };
            clone._gameMoves.AddRange(_gameMoves);
            
            clone._currentState = new State?[Size, Size];
            for (var y = 0; y < Size; y++)
            for (var x = 0; x < Size; x++)
                clone._currentState[x, y] = _currentState[x, y];

            return clone;
        }

        /// <inheritdoc/>
        public void MakeMove(Player player, byte x,  byte y)
        {
            if (x >= Size)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y >= Size)
                throw new ArgumentOutOfRangeException(nameof(y));

            if (IsGameOver)
                return;

            if (_currentState == null)
                _currentState = new State?[Size, Size];

            if (CurrentState[x, y] != null)
                throw new Exception($"Поле ({x}, {y}) уже занято");

            var state = player == Player.Human
                ? State.Cross
                : State.Zero;
            var gameMove = new GameMove(player, x, y, state);
            _gameMoves.Add(gameMove);

            _currentState[x, y] = state;

            OnMove?.Invoke(gameMove);
        }

        /// <inheritdoc/>
        public void CheckWinner(IWinDetector winDetector)
        {
            // если уже есть победитель
            Winner = winDetector.GetWinner(this);
            if (Winner != null)
            {
                IsGameOver = true;
                End?.Invoke(Winner);
            }

            // Если всё поле закончилось
            if (_gameMoves.Count == Size * Size)
            {
                IsGameOver = true;
                End?.Invoke(null);
            }
        }
    }
}
