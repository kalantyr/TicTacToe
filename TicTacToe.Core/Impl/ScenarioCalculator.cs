using System;
using System.Collections.Generic;

namespace TicTacToe.Core.Impl
{
    public class ScenarioCalculator : IScenarioCalculator
    {
        private readonly IWinDetector _winDetector;

        public ScenarioCalculator(IWinDetector winDetector)
        {
            _winDetector = winDetector ?? throw new ArgumentNullException(nameof(winDetector));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<Scenario> Generate(IGame game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            var scenarios = new List<Scenario>();

            for (byte x = 0; x < game.Size; x++)
            {
                for (byte y = 0; y < game.Size; y++)
                {
                    if (game.CurrentState[x, y] != null) continue;

                    var clone = game.Clone();
                    clone.MakeMove(Player.Computer, x, y);
                    clone.CheckWinner(_winDetector);
                    if (clone.Winner == Player.Computer)
                    {
                        var moves = new[] { new GameMove(Player.Computer, x, y, State.Zero) };
                        scenarios.Add(new Scenario(moves, Player.Computer));
                    }
                    //if (clone.Winner == Player.Human)
                    //{
                    //    var moves = new[] { new GameMove(Player.Human, x, y, State.Cross) };
                    //    scenarios.Add(new Scenario(moves, Player.Human));
                    //}
                }
            }

            return scenarios;
        }
    }
}
