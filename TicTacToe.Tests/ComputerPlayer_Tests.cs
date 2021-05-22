using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe.Tests
{
    public class ComputerPlayer_Tests
    {
        private readonly WinDetector _winDetector = new WinDetector();
        private readonly IScenarioCalculator _scenarioCalculator;

        public ComputerPlayer_Tests()
        {
            _scenarioCalculator = new ScenarioCalculator(_winDetector);
        }

        [Test]
        public void GetLastMove_Test2()
        {
            var game = new Game();
            game.MakeMove(Player.Human, 0, 0);
            game.MakeMove(Player.Computer, 2, 0);
            game.MakeMove(Player.Human, 0, 1);
            game.MakeMove(Player.Computer, 1, 1);
            game.MakeMove(Player.Human, 1, 0);

            var computerPlayer = new ComputerPlayer(_winDetector, _scenarioCalculator);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(0, x);
            Assert.AreEqual(2, y);
        }

        [Test]
        public void GetLastMove_Test5()
        {
            var game = new Game();
            game.MakeMove(Player.Human, 0, 0);
            game.MakeMove(Player.Computer, 1, 2);
            game.MakeMove(Player.Human, 1, 1);

            var computerPlayer = new ComputerPlayer(_winDetector, _scenarioCalculator);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(2, x);
            Assert.AreEqual(2, y);
        }
    }
}
