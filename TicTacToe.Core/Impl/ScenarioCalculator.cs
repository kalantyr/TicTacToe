using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core.Impl
{
    public class ScenarioCalculator : IScenarioCalculator
    {
        /// <summary>
        /// На какую глубину ходов просчитывать
        /// </summary>
        private const int MaxDeep = 3;

        private readonly IWinDetector _winDetector;
        private readonly Random _rand = new Random();

        public ScenarioCalculator(IWinDetector winDetector)
        {
            _winDetector = winDetector ?? throw new ArgumentNullException(nameof(winDetector));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<Scenario> Generate(IGame game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            return Calculate(game, 0);
        }

        private IReadOnlyCollection<Scenario> Calculate(IGame game, int deppCount)
        {
            var scenarios = new List<Scenario>();

            if (deppCount > MaxDeep)
                return scenarios;

            if (game.Moves.Count < game.Size / 2 + 1)
            {
                // Если сделано ещё слишком мало ходов, делаем случайный ход
                var clone = game.Clone();
                var (x, y) = GetRandomFreeField(game);
                clone.MakeMove(Player.Computer, x, y);
                scenarios.Add(new Scenario(clone.Moves, null));
                return scenarios;
            }

            for (byte x = 0; x < game.Size; x++)
            {
                for (byte y = 0; y < game.Size; y++)
                {
                    if (game.CurrentState[x, y] != null) continue;

                    var clone = game.Clone();

                    var player = game.Moves.Last().Player == Player.Human
                        ? Player.Computer
                        : Player.Human;
                    clone.MakeMove(player, x, y);

                    clone.CheckWinner(_winDetector);
                    if (clone.Winner == Player.Computer)
                        scenarios.Add(new Scenario(clone.Moves, Player.Computer));

                    if (clone.Winner == null && !clone.IsGameOver)
                    {
                        var nextScenarios = Calculate(clone, deppCount + 1);
                        scenarios.AddRange(nextScenarios);
                    }
                }
            }

            return scenarios;
        }

        /// <summary>
        /// Возвращает случайную пустую клетку
        /// </summary>
        private (byte, byte) GetRandomFreeField(IGameInfo game)
        {
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
