using System;

namespace TicTacToe.Core.Impl
{
    public class ComputerPlayer: IPlayer
    {
        private readonly Random _rand = new Random();

        public (byte, byte) NextMove(IGameInfo game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            // TODO: тут нужно решить, куда компьютеру поставить "нолик"

            var xy = GetHorizontalLastMove(game);
            if (xy != null)
                return xy.Value;
            
            xy = GetVerticalLastMove(game);
            if (xy != null)
                return xy.Value;
            
            xy = GetDiagonal1LastMove(game);
            if (xy != null)
                return xy.Value;  
            
            xy = GetDiagonal2LastMove(game);
            if (xy != null)
                return xy.Value;

            // этот алгоритм выдаёт случайную пустую клетку
            do
            {
                var x = (byte)_rand.Next(0, 3);
                var y = (byte)_rand.Next(0, 3);
                if (game.CurrentState[x, y] == null)
                    return (x, y);
            } while (true);

            //return (x, y);
        }
        public (byte, byte)? GetHorizontalLastMove(IGameInfo game)
        {
            for (byte y = 0; y < game.Size; y++)
            {
                var zeroCount = 0;
                var nullCount = 0;
                byte nullX = 0;
                for (byte x = 0; x < game.Size; x++)
                {
                    if (game.CurrentState[x, y] == null)
                    {
                        nullCount++;
                        nullX = x;
                    }
                    if (game.CurrentState[x, y] == State.Zero)
                        zeroCount++;
                }
                if (zeroCount == game.Size - 1)
                    if (nullCount > 0)
                        return (nullX, y);
            }
            return null;
        }        
        
        public (byte, byte)? GetVerticalLastMove(IGameInfo game)
        {
            for (byte x = 0; x < game.Size; x++)
            {
                var zeroCount = 0;
                var nullCount = 0;
                byte nullY = 0;
                for (byte y = 0; y < game.Size; y++)
                {
                    if (game.CurrentState[x, y] == null)
                    {
                        nullCount++;
                        nullY = y;
                    }
                    if (game.CurrentState[x, y] == State.Zero)
                        zeroCount++;
                }
                if (zeroCount == game.Size - 1)
                    if (nullCount > 0)
                        return (x, nullY);
            }
            return null;
        }
        
        public (byte, byte)? GetDiagonal1LastMove(IGameInfo game)
        {
            for (byte x = 0; x < game.Size; x++)
            {
                var zeroCount = 0;
                var nullCount = 0;
                byte nullY = 0;
                byte y = x;
                if (game.CurrentState[x, y] == null)
                {
                    nullCount++;
                    nullY = y;
                }
                if (game.CurrentState[x, y] == State.Zero)
                    zeroCount++;
                if (zeroCount == game.Size - 1)
                    if (nullCount > 0)
                        return (nullY, nullY);
            }
            return null;
        }   
        
        public (byte, byte)? GetDiagonal2LastMove(IGameInfo game)
        {
            for (byte x = 0; x < game.Size; x++)
            {
                var zeroCount = 0;
                var nullCount = 0;
                byte nullX = 0;
                byte nullY = 0;
                byte y = (byte)(2-x);
                if (game.CurrentState[x, y] == null)
                {
                    nullCount++;
                    nullX = x;
                    nullY = y;
                }
                    if (game.CurrentState[x, y] == State.Zero)
                        zeroCount++;
                if (zeroCount == game.Size - 1)
                    if (nullCount > 0)
                        return (nullX, nullY);
            }
            return null;
        }
    }
}
