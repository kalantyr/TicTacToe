using Moq;
using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe.Tests
{
    public class ComputerPlayer_Tests
    {
        [Test]
        public void GetHorizontalLastMove_Test()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Zero;
            state[1, 0] = null;
            state[2, 0] = State.Zero;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer();
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(1, x);
            Assert.AreEqual(0, y);
        }
    }
}
