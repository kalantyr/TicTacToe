using System;
using System.Collections.Generic;

namespace TicTacToe.Core
{
    /// <summary>
    /// Сценарий дальнейшего развития игры
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// Последовательность ходов
        /// </summary>
        public IReadOnlyCollection<GameMove> GameMoves { get; }

        /// <summary>
        /// Определяет оценку сценария.
        /// -1, если быстрый выигрыш человека
        /// 0, если ничья
        /// 1, если быстрый выигрыш компьютера
        /// </summary>
        public float Evaluation
        {
            get
            {
                // TODO: тут надо вычислять оценку
                throw new NotImplementedException();
            }
        }

        public Scenario(IReadOnlyCollection<GameMove> gameMoves)
        {
            GameMoves = gameMoves ?? throw new ArgumentNullException(nameof(gameMoves));
        }
    }
}
