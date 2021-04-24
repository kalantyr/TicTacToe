namespace TicTacToe.Core
{
    /// <summary>
    /// Умеет определять победителя игры
    /// </summary>
    public interface IWinDetector
    {
        /// <summary>
        /// Определяет победителя игры
        /// <see cref="null"/>, если "ничья"
        /// </summary>
        Player? GetWinner(IGameInfo game);
    }
}
