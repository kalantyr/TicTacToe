﻿using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe.Tests
{
    public class ComputerPlayer_Tests
    {
        private readonly WinDetector _winDetector = new WinDetector();

        [Test]
        public void GetHorizontalLastMove_Test()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 0, 0);
            game.MakeMove(Player.Computer, 2, 0);

            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(1, x);
            Assert.AreEqual(0, y);
        }
        
        [Test]
        public void GetVerticalLastMove_Test()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 0, 0);
            game.MakeMove(Player.Computer, 0, 1);

            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(0, x);
            Assert.AreEqual(2, y);
        }  
        
        [Test]
        public void GetVerticalLastMove_Test2()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 1, 1);
            game.MakeMove(Player.Computer, 1, 2);

            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(1, x);
            Assert.AreEqual(0, y);
        }     
        
        [Test]
        public void GetDiagonal1LastMove_Test()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 0, 0);
            game.MakeMove(Player.Computer, 2, 2);


            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(1, x);
            Assert.AreEqual(1, y);
        } 
        [Test]
        public void GetDiagonal1LastMove_Test2()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 1, 1);
            game.MakeMove(Player.Computer, 2, 2);

            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }     
        
        [Test]
        public void GetDiagonal2LastMove_Test()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 0, 2);
            game.MakeMove(Player.Computer, 1, 1);

            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(2, x);
            Assert.AreEqual(0, y);
        }      
        
        [Test]
        public void GetDiagonal2LastMove_Test2()
        {
            var game = new Game();
            game.MakeMove(Player.Computer, 1, 1);
            game.MakeMove(Player.Computer, 2, 0);

            var computerPlayer = new ComputerPlayer(_winDetector);
            var (x, y) = computerPlayer.NextMove(game);
            Assert.AreEqual(0, x);
            Assert.AreEqual(2, y);
        }
    }
}
