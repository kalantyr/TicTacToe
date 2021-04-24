using System;
using System.Collections.Generic;

namespace TicTacToe.Core
{
    public class Game
    {
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public const byte Width = 3;

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public const byte Height = 3;

        private readonly IList<GameMove> _gameMoves = new List<GameMove>();

        public State?[,] CurrentState
        {
            get
            {
                var currentState = new State?[Width, Height];
                throw new NotImplementedException();
                return currentState;
            }
        }

        /// <summary>
        /// Событие случается, когда сделан ход
        /// </summary>
        public event Action<GameMove> OnMove;

        /// <summary>
        /// Сделать ход
        /// (Человек ставит крестики, компьютер - нолики)
        /// </summary>
        /// <param name="player">Кто делает ход</param>
        /// <param name="x">Позиция по горизонтали [0..<see cref="Width"/>]</param>
        /// <param name="y">Позиция по вертикали [0..<see cref="Height"/>]</param>
        public GameMove MakeMove(Player player, byte x,  byte y)
        {
            if (x >= Width)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y >= Height)
                throw new ArgumentOutOfRangeException(nameof(y));

            var state = player == Player.Human
                ? State.Cross
                : State.Zero;
            var gameMove = new GameMove(player, x, y, state);
            _gameMoves.Add(gameMove);
            OnMove?.Invoke(gameMove);
            return gameMove;
        }
    }
}
