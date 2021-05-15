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

            // TODO: тут нужно перебрать разные сценарии и добавить их в список "scenarios"

            return scenarios;
        }
    }
}
