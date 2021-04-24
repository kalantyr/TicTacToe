using System;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe
{
    public partial class App
    {
        /// <summary>
        /// Текущая игра
        /// </summary>
        internal Game CurrentGame { get; private set; }

        /// <summary>
        /// Случается, когда старая игра прекращается и начинается новая
        /// </summary>
        internal event Action<Game, Game> GameChanged;

        /// <summary>
        /// Искуственный интеллект
        /// </summary>
        public IPlayer ComputerPlayer { get; } = new ComputerPlayer();

        /// <summary>
        /// Начинает новую игру
        /// </summary>
        internal void NewGame()
        {
            var oldGame = CurrentGame;
            CurrentGame = new Game(new WinDetector());
            GameChanged?.Invoke(oldGame, CurrentGame);
        }
    }
}
