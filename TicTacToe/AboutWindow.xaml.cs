using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

namespace TicTacToe
{
    public partial class AboutWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            var uri = ((Hyperlink)sender).NavigateUri;
            var startInfo = new ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true };
            Process.Start(startInfo);
            e.Handled = true;
        }
    }
}
