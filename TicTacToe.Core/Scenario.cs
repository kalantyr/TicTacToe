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
        
        public Player? Winner { get; }

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
                if (Winner == Player.Human)
                    return -1;
                if (Winner == Player.Computer)
                    return 1;
                return 0;

            }
        }

        public Scenario(IReadOnlyCollection<GameMove> gameMoves, Player? winner)
        {
            GameMoves = gameMoves ?? throw new ArgumentNullException(nameof(gameMoves));
            Winner = winner;
        }
    }
}
