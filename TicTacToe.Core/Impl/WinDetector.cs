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
            
            var result = GetHorizontalWinner(game);
            if (result != null)
                return result;
            
            result = GetVerticalWinner(game);
            if (result != null)
                return result;
            
            return null;
        }
        
        private Player? GetHorizontalWinner(IGameInfo game)
        {
            for (var y = 0; y < game.Size; y++)
            {
                var crossCount = 0;
                var zeroCount = 0;
                for (var x = 0; x < game.Size; x++)
                {
                    if (game.CurrentState[x, y] == State.Cross)
                        crossCount++;
                    if (game.CurrentState[x, y] == State.Zero)
                        zeroCount++;
                }
                if (crossCount == game.Size)
                    return Player.Human;                
                if (zeroCount == game.Size)
                    return Player.Computer;
            }
            return null;
        }

        private Player? GetVerticalWinner(IGameInfo game)
        {
            return null;
        }
    }
}
