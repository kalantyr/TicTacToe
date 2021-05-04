using Moq;
using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe.Tests
{
    public class ComputerPlayer_Tests
    {
        private readonly WinDetector _winDetector = new WinDetector();

        [Test]
        public void NextMove_Test()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Cross;
            state[0, 1] = State.Zero;

            var game = new Mock<IGame>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }
    }
}
