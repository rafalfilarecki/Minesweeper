using System;
using System.Windows;

namespace Minesweeper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            int rows = int.Parse(RowsTextBox.Text);
            int columns = int.Parse(ColumnsTextBox.Text);
            int mines = int.Parse(MinesTextBox.Text);

            GameWindow gameWindow = new GameWindow(rows, columns, mines);
            gameWindow.Show();
            this.Close();
        }
    }
}
