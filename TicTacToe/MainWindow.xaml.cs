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
            ((App)Application.Current).CurrentGame.MakeMove(Player.Human, x, y);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).NewGame();
        }

        private void OnGameChanged(Core.Game oldGame, Core.Game newGame)
        {
            _gameControl.Game = newGame;
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
