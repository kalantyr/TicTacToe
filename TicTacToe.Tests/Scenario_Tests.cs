using NUnit.Framework;
using TicTacToe.Core;


namespace TicTacToe.Tests
{
    public class Scenario_Tests
    {
        [TestCase(Player.Computer, 1)]
        [TestCase(Player.Human, -1)]
        [TestCase(null, 0)]
        public void Evaluation_Test(Player? winner, float expectedEvoluation)
        {
            var moves = new[]
            {
                new GameMove(Player.Computer,1,1, State.Zero)
            };
            var s = new Scenario(moves, winner);
            Assert.AreEqual(expectedEvoluation, s.Evaluation);

        }
    }
}
