using NUnit.Framework;
using TicTacToe.Core;

namespace TicTacToe.Tests
{
    public class Game_Tests
    {
        [Test]
        public void CurrentState_Test()
        {
            var game = new Game();
            game.MakeMove(Player.Human, 1, 1);
            game.MakeMove(Player.Computer, 2, 2);
            var game2 = game.Clone();
            Assert.AreEqual(State.Cross, game2.CurrentState[1, 1]);
            Assert.AreEqual(State.Zero, game2.CurrentState[2, 2]);
        }
    }
}
