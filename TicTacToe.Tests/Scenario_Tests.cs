using NUnit.Framework;
using System.Collections.Generic;
using TicTacToe.Core;


namespace TicTacToe.Tests
{
    public class Scenario_Tests
    {
        [TestCase(Player.Computer, 1, 1)]
        [TestCase(Player.Computer, 2, 0.5f)]
        [TestCase(Player.Human, 1,-1)]
        [TestCase(Player.Human, 2,-0.5f)]
        [TestCase(null, 1, 0)]
        [TestCase(null, 2, 0)]
        public void Evaluation_Test(Player? winner, int moveCount, float expectedEvoluation)
        {
            var moves = new List<GameMove>();
            for (byte i=0; i<moveCount; i++)
            {
                moves.Add(new GameMove(Player.Computer, i, 1, State.Zero));
            }
            var s = new Scenario(moves, winner);
            Assert.AreEqual(expectedEvoluation, s.Evaluation);

        }
    }
}
