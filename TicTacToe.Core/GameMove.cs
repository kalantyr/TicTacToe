using System.Diagnostics;

namespace TicTacToe.Core
{
    /// <summary>
    /// Ход в игре
    /// </summary>
    [DebuggerDisplay("{Player} ({X}, {Y})")]
    public class GameMove
    {
        /// <summary>
        /// Кто сделал ход
        /// </summary>
        public Player Player { get; }

        public byte X { get; }

        public byte Y { get; }

        /// <summary>
        /// Что наприсовано в клетке
        /// </summary>
        public State State { get; }

        public GameMove(Player player, byte x, byte y, State state)
        {
            Player = player;
            X = x;
            Y = y;
            State = state;
        }
    }
}
