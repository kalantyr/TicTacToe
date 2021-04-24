using System;

namespace TicTacToe.Core.Impl
{
    public class ComputerPlayer: IPlayer
    {
        public (byte, byte) NextMove(IGameInfo game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            // TODO: тут нужно решить, куда компьютеру поставить "нолик"

            byte x = 0;
            byte y = 0;

            return (x, y);
        }
    }
}
