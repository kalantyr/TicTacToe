using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe.Tests
{
    public class ScenarioCalculator_Tests
    {
        [Test]
        public void Generate_Test()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 1, 0);
            game.MakeMove(Player.Computer, 2, 0);
            var calc = new ScenarioCalculator(new WinDetector());
            var scenarios = calc.Generate(game);
            Assert.IsTrue(scenarios.Count > 0);
        }
    }
}
