﻿using Moq;
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
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.IsNull(result);
        }       
       
        [Test]
        public void GetWinner_Test_2()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Cross;
            state[1, 0] = State.Cross;
            state[2, 0] = State.Cross;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(Player.Human, result);
        }
       
        [Test]
        public void GetWinner_Test_3()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Cross;
            state[1, 0] = State.Zero;
            state[2, 0] = State.Cross;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.Size).Returns(3);
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(null, result);
        } 
        
        [Test]
        public void GetWinner_Test_Vertical()
        {
            var state = new State?[3, 3];
            state[2, 0] = State.Zero;
            state[2, 1] = State.Zero;
            state[2, 2] = State.Zero;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(Player.Computer, result);
        }      
        
        [Test]
        public void GetWinner_Test_Vertical2()
        {
            var state = new State?[3, 3];
            state[2, 0] = State.Cross;
            state[2, 1] = State.Zero;
            state[2, 2] = State.Zero;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(null, result);
        }  
        
        [Test]
        public void GetWinner_Test_Diagonal()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Cross;
            state[1, 1] = State.Cross;
            state[2, 2] = State.Cross;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(Player.Human, result);
        }  
        
        [Test]
        public void GetWinner_Test_Diagonal2()
        {
            var state = new State?[3, 3];
            state[0, 0] = State.Cross;
            state[1, 1] = State.Cross;
            state[2, 2] = null;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(null, result);
        }
        
        [Test]
        public void GetWinner_Test_Diagonal3()
        {
            var state = new State?[3, 3];
            state[0, 1] = State.Cross;
            state[1, 2] = State.Cross;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(null, result);
        }


        [Test]
        public void GetWinner_Test_Diagonal4()
        {
            var state = new State?[3, 3];
            state[0, 2] = State.Cross;
            state[1, 1] = State.Cross;
            state[2, 0] = State.Cross;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(Player.Human, result);
        }

        [Test]
        public void GetWinner_Test_Diagonal5()
        {
            var state = new State?[3, 3];
            state[0, 2] = State.Cross;
            state[1, 1] = null;
            state[2, 0] = State.Cross;


            var game = new Mock<IGameInfo>();
            game.Setup(g => g.CurrentState).Returns(state);

            var winDetector = new WinDetector();
            var result = winDetector.GetWinner(game.Object);
            Assert.AreEqual(null, result);
        }
    }
}
