namespace TicTacToe.Core
{
    public interface IPlayer
    {
        /// <summary>
        /// Возвращает (x, y) следующего хода
        /// </summary>
        (byte, byte) NextMove(IGame game);
    }
}
