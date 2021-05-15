using System.Collections.Generic;

namespace TicTacToe.Core.Impl
{
    /// <summary>
    /// Умеет просчитывать сценарии развития игры
    /// </summary>
    public interface IScenarioCalculator
    {
        /// <summary>
        /// Возвращает все возможные сценарии
        /// </summary>
        IReadOnlyCollection<Scenario> Generate(IGame game);
    }
}