using System;

namespace TicTacToe.Core.Impl
{
    public class WinDetector: IWinDetector
    {
        /// <summary>
        /// Количетво ячеек достаточное для победы
        /// </summary>
        public const byte WinSeqSize = 3; 

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
                    {
                        crossCount++;
                        zeroCount = 0;
                    }
                    if (game.CurrentState[x, y] == State.Zero)
                    {
                        zeroCount++;
                        crossCount = 0;
                    }
                    if (game.CurrentState[x,y] == null)
                    {
                        zeroCount = 0;
                        crossCount = 0;
                    }
                    if (crossCount == WinSeqSize)
                        return Player.Human;
                    if (zeroCount == WinSeqSize)
                        return Player.Computer;
                }
            }
            return null;
        }

        private Player? GetVerticalWinner(IGameInfo game)
        {
            for (var x = 0; x<game.Size; x++)
            {
                var crossCount = 0;
                var zeroCount = 0;
                for (var y = 0; y<game.Size; y++)
                {
                    if (game.CurrentState[x, y] == State.Cross)
                    { 
                        crossCount++;
                        zeroCount = 0;
                    }
                    if (game.CurrentState[x, y] == State.Zero)
                    {
                        zeroCount++;
                        crossCount = 0;
                    }
                    if (game.CurrentState[x, y] == null)
                    {
                        zeroCount = 0;
                        crossCount = 0;
                    }
                    if (crossCount == WinSeqSize)
                        return Player.Human;
                    if (zeroCount == WinSeqSize)
                        return Player.Computer;
                }
            }
            return null;
        }

        private Player? GetDiagonalWinner1(IGameInfo game)
        {
            var crossCount = 0;
            var zeroCount = 0;
            for (var offset = -game.Size; offset < game.Size; offset++)
            {
                for (var x = 0; x < game.Size; x++)
                {
                    var y = x + offset;
                    if (y < 0) continue;
                    if (y >= game.Size) continue;
                    if (game.CurrentState[x, y] == State.Cross)
                    { 
                        crossCount++;
                        zeroCount = 0;
                    }
                    if (game.CurrentState[x, y] == State.Zero)
                    {
                        zeroCount++;
                        crossCount = 0;
                    }
                    if (game.CurrentState[x, y] == null)
                    {
                        zeroCount = 0;
                        crossCount = 0;
                    }

                    if (crossCount == WinSeqSize)
                        return Player.Human;
                    if (zeroCount == WinSeqSize)
                        return Player.Computer;
                }
                crossCount = 0;
                zeroCount = 0;
            }

            return null;
        }

        private Player? GetDiagonalWinner2(IGameInfo game)
        {
            var crossCount = 0;
            var zeroCount = 0;
            for (var offset = -game.Size; offset < game.Size; offset++)
            {
                for (var x = game.Size - 1; x > -1; x--)
                {
                    var y = game.Size - 1 - x + offset;
                    if (y < 0) continue;
                    if (y >= game.Size) continue;
                    if (game.CurrentState[x, y] == State.Cross)
                    {
                        crossCount++;
                        zeroCount = 0;
                    }
                    if (game.CurrentState[x, y] == State.Zero)
                    {
                        zeroCount++;
                        crossCount = 0;
                    }
                    if (game.CurrentState[x, y] == null)
                    {
                        zeroCount = 0;
                        crossCount = 0;
                    }

                    if (crossCount == WinSeqSize)
                        return Player.Human;
                    if (zeroCount == WinSeqSize)
                        return Player.Computer;
                }
                crossCount = 0;
                zeroCount = 0;
            }

            return null;
        }

    }
}
