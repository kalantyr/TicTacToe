using System;
using TicTacToe.Core;

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

        internal void NewGame()
        {
            var oldGame = CurrentGame;
            CurrentGame = new Game();
            GameChanged?.Invoke(oldGame, CurrentGame);
        }
    }
}
