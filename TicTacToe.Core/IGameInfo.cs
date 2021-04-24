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
        /// Размер игровоо поля (по ширине и высоте)
        /// </summary>
        byte Size { get; }

        /// <summary>
        /// Игра завершена
        /// </summary>
        public bool IsGameOver { get; }
    }
}