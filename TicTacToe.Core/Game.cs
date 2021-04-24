﻿using System;
using System.Collections.Generic;

namespace TicTacToe.Core
{
    public class Game : IGameInfo
    {
        private readonly IWinDetector _winDetector;

        private readonly IList<GameMove> _gameMoves = new List<GameMove>();

        /// <inheritdoc/>
        public State?[,] CurrentState
        {
            get
            {
                var currentState = new State?[Size, Size];
                foreach (var move in _gameMoves)
                    currentState[move.X, move.Y] = move.State;
                return currentState;
            }
        }

        /// <inheritdoc/>
        public byte Size { get; } = 3;

        /// <summary>
        /// Событие случается, когда сделан ход
        /// </summary>
        public event Action<GameMove> OnMove;

        /// <summary>
        /// Случается, когда игра завершена (передаётся победитель)
        /// </summary>
        public event Action<Player?> End;

        /// <inheritdoc/>
        public bool IsGameOver { get; private set; }

        public Game(IWinDetector winDetector)
        {
            _winDetector = winDetector ?? throw new ArgumentNullException(nameof(winDetector));
        }

        /// <summary>
        /// Сделать ход
        /// (Человек ставит крестики, компьютер - нолики)
        /// </summary>
        /// <param name="player">Кто делает ход</param>
        /// <param name="x">Позиция по горизонтали [0..<see cref="Width"/>]</param>
        /// <param name="y">Позиция по вертикали [0..<see cref="Height"/>]</param>
        public void MakeMove(Player player, byte x,  byte y)
        {
            if (x >= Size)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y >= Size)
                throw new ArgumentOutOfRangeException(nameof(y));

            if (IsGameOver)
                return;

            if (CurrentState[x, y] != null)
                throw new Exception($"Поле ({x}, {y}) уже занято");

            var state = player == Player.Human
                ? State.Cross
                : State.Zero;
            var gameMove = new GameMove(player, x, y, state);
            _gameMoves.Add(gameMove);
            OnMove?.Invoke(gameMove);

            // если уже есть победитель
            var winner = _winDetector.GetWinner(this);
            if (winner != null)
            {
                IsGameOver = true;
                End?.Invoke(winner);
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
