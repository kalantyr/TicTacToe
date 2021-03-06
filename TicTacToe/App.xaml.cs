using System;
using TicTacToe.Core;
using TicTacToe.Core.Impl;

namespace TicTacToe
{
    public partial class App
    {
        private readonly WinDetector _winDetector = new WinDetector();
        private readonly ComputerPlayer _computerPlayer;

        public App()
        {
            _computerPlayer = new ComputerPlayer(_winDetector, new ScenarioCalculator(_winDetector));
        }

        /// <summary>
        /// Текущая игра
        /// </summary>
        internal IGame CurrentGame { get; private set; }

        /// <summary>
        /// Случается, когда старая игра прекращается и начинается новая
        /// </summary>
        internal event Action<IGame, IGame> GameChanged;

        /// <summary>
        /// Определитель победы
        /// </summary>
        public IWinDetector WinDetector => _winDetector;

        /// <summary>
        /// Искуственный интеллект
        /// </summary>
        public IPlayer ComputerPlayer => _computerPlayer;

        /// <summary>
        /// Начинает новую игру
        /// </summary>
        internal void NewGame(byte size)
        {
            var oldGame = CurrentGame;
            CurrentGame = new Game(size);
            GameChanged?.Invoke(oldGame, CurrentGame);
        }
    }
}
