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
        
        [Test]
        public void GetVerticalLastMove_Test()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Zero;
            state[0, 1] = State.Zero;
            state[0, 2] = null;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer();
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(0, x);
            Assert.AreEqual(2, y);
        }  
        
        [Test]
        public void GetVerticalLastMove_Test2()
        {
            var state = new State?[3, 3];
            state[1, 0] = null;
            state[1, 1] = State.Zero;
            state[1, 2] = State.Zero;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer();
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(1, x);
            Assert.AreEqual(0, y);
        }     
        
        [Test]
        public void GetDiagonal1LastMove_Test()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Zero;
            state[1, 1] = null;
            state[2, 2] = State.Zero;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer();
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(1, x);
            Assert.AreEqual(1, y);
        } 
        [Test]
        public void GetDiagonal1LastMove_Test2()
        {
            var state = new State?[3, 3];
            state[0, 0] = null;
            state[1, 1] = State.Zero;
            state[2, 2] = State.Zero;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer();
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }     
        
        [Test]
        public void GetDiagonal2LastMove_Test()
        {
            var state = new State?[3, 3];
            state[0, 2] = State.Zero;
            state[1, 1] = State.Zero;
            state[2, 0] = null;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer();
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(2, x);
            Assert.AreEqual(0, y);
        }      
        
        [Test]
        public void GetDiagonal2LastMove_Test2()
        {
            var state = new State?[3, 3];
            state[0, 2] = null;
            state[1, 1] = State.Zero;
            state[2, 0] = State.Zero;

            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var computerPlayer = new ComputerPlayer();
            var (x, y) = computerPlayer.NextMove(game.Object);
            Assert.AreEqual(0, x);
            Assert.AreEqual(2, y);
        }
    }
}
