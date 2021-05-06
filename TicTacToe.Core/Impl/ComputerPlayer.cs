using System;

namespace TicTacToe.Core.Impl
{
    public class ComputerPlayer: IPlayer
    {
        private readonly IWinDetector _winDetector;
        private readonly Random _rand = new Random();

        public ComputerPlayer(IWinDetector winDetector)
        {
            _winDetector = winDetector ?? throw new ArgumentNullException(nameof(winDetector));
        }

        public (byte, byte) NextMove(IGame game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));
            
            // Поиск выигрышного последнего ходя для компьютера
            for (byte x=0; x<game.Size; x++)
            {
                for (byte y=0; y<game.Size; y++)
                {
                    if (game.CurrentState[x, y] != null) continue;
                    
                    var clone = game.Clone();
                    clone.MakeMove(Player.Computer, x, y);
                    clone.CheckWinner(_winDetector);
                    if (clone.Winner == Player.Computer)
                        return (x, y);
                }
            }

             //Предотвращение выигрышного хода человека
            for (byte x=0; x<game.Size; x++)
            {
                for (byte y=0; y<game.Size; y++)
                {
                    if (game.CurrentState[x, y] != null) continue;
                    
                    var clone = game.Clone();
                    clone.MakeMove(Player.Human, x, y);
                    clone.CheckWinner(_winDetector);
                    if (clone.Winner == Player.Human)
                        return (x, y);
                }
            }

            if (game.CurrentState[1, 1] == null)
                return (1, 1);

            do
            {
                var x = (byte)_rand.Next(0, 3);
                var y = (byte)_rand.Next(0, 3);
                if (game.CurrentState[x, y] == null)
                    return (x, y);
            } while (true);
        }
    }
}
