using System;

namespace TicTacToe.Core.Impl
{
    public class WinDetector: IWinDetector
    {
        /// <inheritdoc/>
        public Player? GetWinner(IGameInfo game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            // TODO: тут нужно реализовать алгоритм поиска победителя
            // человек играет "крестиками", компьютер - "ноликами"

            return null;
        }
    }
}
