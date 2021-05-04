using System;

namespace TicTacToe.Core
{
    public interface IGame: IGameInfo
    {
        /// <summary>
        /// Игра завершена
        /// </summary>
        bool IsGameOver { get; }

        /// <summary>
        /// Победитель
        /// </summary>
        Player? Winner { get; }

        /// <summary>
        /// Создаёт отдельную копию игры (без подписчиков)
        /// </summary>
        IGame Clone();

        /// <summary>
        /// Сделать ход
        /// (Человек ставит крестики, компьютер - нолики)
        /// </summary>
        /// <param name="player">Кто делает ход</param>
        /// <param name="x">Позиция по горизонтали [0..<see cref="Width"/>]</param>
        /// <param name="y">Позиция по вертикали [0..<see cref="Height"/>]</param>
        void MakeMove(Player player, byte x, byte y);

        /// <summary>
        /// Проверяет, появился ли победитель
        /// </summary>
        void CheckWinner(IWinDetector winDetector);

        /// <summary>
        /// Событие случается, когда сделан ход
        /// </summary>
        event Action<GameMove> OnMove;

        /// <summary>
        /// Случается, когда игра завершена (передаётся победитель)
        /// </summary>
        event Action<Player?> End;
    }
}
