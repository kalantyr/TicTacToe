using System.Windows;
using TicTacToe.Core;

namespace TicTacToe.UserControls
{
    public partial class FieldControl
    {
        private State _state;

        public FieldControl()
        {
            InitializeComponent();
        }

        public State State
        {
            get => _state;
            set
            {
                _state = value;

                _tbCross.Visibility = _state == State.Cross ? Visibility.Visible : Visibility.Collapsed;
                _tbZero.Visibility = _state == State.Zero ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
