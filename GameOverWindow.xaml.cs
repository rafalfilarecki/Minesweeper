using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper
{
    public partial class GameOverWindow : Window
    {
        public GameOverWindow(string message)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
