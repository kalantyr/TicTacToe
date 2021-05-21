using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TicTacToe.Core
{
    /// <summary>
    /// Сценарий дальнейшего развития игры
    /// </summary>
    [DebuggerDisplay("{Winner} оценка={Evaluation}")]
    public class Scenario
    {
        /// <summary>
        /// Последовательность ходов
        /// </summary>
        public IReadOnlyCollection<GameMove> Moves { get; }
        
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
                    return (float)(-1)/Moves.Count;
                if (Winner == Player.Computer)
                    return (float)1/Moves.Count;
                return 0;

            }
        }

        public Scenario(IReadOnlyCollection<GameMove> gameMoves, Player? winner)
        {
            Moves = gameMoves ?? throw new ArgumentNullException(nameof(gameMoves));
            Winner = winner;
        }
    }
}
