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
            
            result = GetDiagonalWinner1(game);
            if (result != null)
                return result;

            result = GetDiagonalWinner2(game);
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
            for (var x = 0; x<3; x++)
            {
                var crossCount = 0;
                var zeroCount = 0;
                for (var y = 0; y<3; y++)
                {
                    if (game.CurrentState[x, y] == State.Cross)
                        crossCount++;
                    if (game.CurrentState[x, y] == State.Zero)
                        zeroCount++;
                }
                if (crossCount == 3)
                    return Player.Human;                
                if (zeroCount == 3)
                    return Player.Computer;
            }
            return null;
        }
        
        private Player? GetDiagonalWinner1(IGameInfo game)
        {
                var crossCount = 0;
                var zeroCount = 0;
            for (var x = 0; x<3; x++)
            {
                var y = x;
                if (game.CurrentState[x, y] == State.Cross)
                    crossCount++;

                if (game.CurrentState[x, y] == State.Zero)
                    zeroCount++;

                if (crossCount == 3)
                    return Player.Human;
                if (zeroCount == 3)
                    return Player.Computer;
            }
            return null;
        }        
        
        private Player? GetDiagonalWinner2(IGameInfo game)
        {
                var crossCount = 0;
                var zeroCount = 0;
            for (var x = 2; x > -1; x--)
            {
                var y = 2 - x;
                if (game.CurrentState[x, y] == State.Cross)
                {
                    crossCount++;
                }
                if (game.CurrentState[x, y] == State.Zero)
                    zeroCount++;

                if (crossCount == 3)
                    return Player.Human;
                if (zeroCount == 3)
                    return Player.Computer;
            }
            return null;        
        }
            
       
    }
}
