using System;
using System.Windows.Controls;
using System.Windows.Input;
using TicTacToe.Core;

namespace TicTacToe.UserControls
{
    public partial class GameControl
    {
        private IGame _game;

        /// <summary>
        /// Когда кликнули мышкой на игровое поле
        /// </summary>
        public event Action<byte, byte> FieldSelected;

        public IGame Game
        {
            get => _game;
            set
            {
                if (_game == value)
                    return;

                if (_game != null)
                    _game.OnMove -= OnMove;

                _grid.Children.Clear();

                _game = value;

                if (_game != null)
                    _game.OnMove += OnMove;
            }
        }

        private void OnMove(GameMove gameMove)
        {
            var fc = new FieldControl { State = gameMove.State };
            Grid.SetColumn(fc, gameMove.X);
            Grid.SetRow(fc, gameMove.Y);
            _grid.Children.Add(fc);
        }

        public GameControl()
        {
            InitializeComponent();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (FieldSelected == null)
                return;

            var mousePos = e.GetPosition(this);

            var x = mousePos.X / ActualWidth;
            var y = mousePos.Y / ActualHeight;
            var xb = (byte)(Game.Size * x);
            var yb = (byte)(Game.Size * y);
            FieldSelected.Invoke(xb, yb);
        }
    }
}
