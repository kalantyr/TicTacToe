using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
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

                _grdFields.Children.Clear();
                _grdFields.RowDefinitions.Clear();
                _grdFields.ColumnDefinitions.Clear();

                _grid.RowDefinitions.Clear();
                _grid.ColumnDefinitions.Clear();

                if (_game != null)
                {
                    FillGrdFields();

                    for (var y = 0; y < _game.Size; y++)
                        _grid.RowDefinitions.Add(new RowDefinition());
                    for (var x = 0; x < _game.Size; x++)
                        _grid.ColumnDefinitions.Add(new ColumnDefinition());

                    _game.OnMove += OnMove;
                }
            }
        }

        private void FillGrdFields()
        {
            var style = (Style)FindResource("rect");

            for (var y = 0; y < _game.Size; y++)
                _grdFields.RowDefinitions.Add(new RowDefinition());
            for (var x = 0; x < _game.Size; x++)
                _grdFields.ColumnDefinitions.Add(new ColumnDefinition());

            for (var y = 0; y < _game.Size; y++)
            for (var x = 0; x < _game.Size; x++)
            {
                var rect = new Rectangle {Style = style};
                Grid.SetRow(rect, y);
                Grid.SetColumn(rect, x);
                _grdFields.Children.Add(rect);
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
