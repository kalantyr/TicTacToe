namespace TicTacToe.Core
{
    /// <summary>
    /// Информация об игре
    /// </summary>
    public interface IGameInfo
    {
        /// <summary>
        /// Текущее состояние игрового поля (прямоугольный массив)
        /// </summary>
        State?[,] CurrentState { get; }

        /// <summary>
        /// Игра завершена
        /// </summary>
        public bool IsGameOver { get; }
    }
}