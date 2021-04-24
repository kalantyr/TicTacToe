using Moq;
using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe.Tests
{
    public class WinDetector_Tests
    {
        [Test]
        public void GetWinner_Test()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Cross;
            state[0, 1] = State.Zero;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.IsNull(result);
        }
    }
}
