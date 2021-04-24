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
    }
}
