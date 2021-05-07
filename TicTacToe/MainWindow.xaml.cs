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
            ((App)Application.Current).NewGame(Game.DefaultSize);
        }

        private void OnGameChanged(IGame oldGame, IGame newGame)
        {
            if (oldGame != null)
            {
                oldGame.End -= Game_End;
                newGame.OnMove -= Game_OnMove;
            }

            _gameControl.Game = newGame;

            if (newGame != null)
            {
                if (newGame.Winner == null)
                {
                    _tbWinnerHuman.Visibility = Visibility.Hidden;
                    _tbWinnerComputer.Visibility = Visibility.Hidden;
                }

                newGame.End += Game_End;
                newGame.OnMove += Game_OnMove;
            }
        }

        private void Game_OnMove(GameMove gameMove)
        {
            var game = ((App)Application.Current).CurrentGame;
            var winDetector = ((App)Application.Current).WinDetector;

            // проверяем, не появился ли победитель
            game.CheckWinner(winDetector);
        }

        private void Game_End(Player? winner)
        {
            _tbWinnerHuman.Visibility = winner == Player.Human ? Visibility.Visible : Visibility.Hidden;
            _tbWinnerComputer.Visibility = winner == Player.Computer ? Visibility.Visible : Visibility.Hidden;
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnNewClick(object sender, RoutedEventArgs e)
        {
            var tag = ((FrameworkElement) sender).Tag;
            var size = byte.Parse((string)tag);
            ((App)Application.Current).NewGame(size);
        }

        private void OnAboutClick(object sender, RoutedEventArgs e)
        {
            new AboutWindow { Owner = this }.ShowDialog();
        }
    }
}
