using System;
using System.Linq;

namespace TicTacToe.Core.Impl
{
    public class ComputerPlayer: IPlayer
    {
        private readonly IWinDetector _winDetector;
        private readonly IScenarioCalculator _scenarioCalculator;
        private readonly Random _rand = new Random();

        public ComputerPlayer(IWinDetector winDetector, IScenarioCalculator scenarioCalculator)
        {
            _winDetector = winDetector ?? throw new ArgumentNullException(nameof(winDetector));
            _scenarioCalculator = scenarioCalculator ?? throw new ArgumentNullException(nameof(scenarioCalculator));
        }

        public (byte, byte) NextMove(IGame game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            //Предотвращение выигрышного хода человека
            for (byte x = 0; x < game.Size; x++)
            {
                for (byte y = 0; y < game.Size; y++)
                {
                    if (game.CurrentState[x, y] != null) continue;

                    var clone = game.Clone();
                    clone.MakeMove(Player.Human, x, y);
                    clone.CheckWinner(_winDetector);
                    if (clone.Winner == Player.Human)
                        return (x, y);
                }
            }

            var scenarios = _scenarioCalculator.Generate(game);
            if (scenarios.Any())
            {
                var best = scenarios.OrderBy(s => s.Evaluation).Last();
                var move = best.Moves.Skip(game.Moves.Count).First();
                return (move.X,move.Y);
            }

            if (game.Size == 3)
                if (game.CurrentState[1, 1] == null)
                    return (1, 1);

            do
            {
                var x = (byte)_rand.Next(0, game.Size);
                var y = (byte)_rand.Next(0, game.Size);
                if (game.CurrentState[x, y] == null)
                    return (x, y);
            } while (true);
        }
    }
}
