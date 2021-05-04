using System;
using System.Windows;
using TicTacToe.Core;

namespace TicTacToe
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            _gameControl.FieldSelected += OnFieldSelected;
            ((App)Application.Current).GameChanged += OnGameChanged;

            Loaded += MainWindow_Loaded;
        }

        private void OnFieldSelected(byte x, byte y)
        {
            var game = ((App)Application.Current).CurrentGame;

            // ход Человека
            game.MakeMove(Player.Human, x, y);

            // ход Компьютера
            if (!game.IsGameOver)
            {
                var computer = ((App)Application.Current).ComputerPlayer;
                var (x2, y2) = computer.NextMove(game);
                game.MakeMove(Player.Computer, x2, y2);
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).NewGame();
        }

        private void OnGameChanged(IGame oldGame, IGame newGame)
        {
            if (oldGame != null)
            {
                oldGame.End -= NewGame_End;
                newGame.OnMove -= NewGame_OnMove;
            }

            _gameControl.Game = newGame;

            if (newGame != null)
            {
                newGame.End += NewGame_End;
                newGame.OnMove += NewGame_OnMove;
            }
        }

        private void NewGame_OnMove(GameMove gameMove)
        {
            var game = ((App)Application.Current).CurrentGame;
            var winDetector = ((App)Application.Current).WinDetector;

            // проверяем, не появился ли победитель
            game.CheckWinner(winDetector);
        }

        private void NewGame_End(Player? winner)
        {
            var text = "Игра завершена.";
            if (winner == Player.Computer)
                text += Environment.NewLine + Environment.NewLine + "Победил компьютер.";
            if (winner == Player.Human)
                text += Environment.NewLine + Environment.NewLine + "Поздравляем, Вы победили!";
            MessageBox.Show(this, text, Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnNewClick(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).NewGame();
        }
    }
}
