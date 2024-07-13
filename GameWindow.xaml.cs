using System;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper
{
    public partial class GameWindow : Window
    {
        private Game Game;
        private Button[,] Buttons;

        public  GameWindow(int rows, int columns, int mines)
        {
            InitializeComponent();
            Game = new Game(rows, columns, mines);
            InitializeGrid(rows, columns);
        }

        private void InitializeGrid(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            
            for (int i = 0;i < columns; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            Buttons = new Button[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button();
                    button.Tag = new int[] { i, j };
                    button.Click += Button_Click;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    GameGrid.Children.Add(button);
                    Buttons[i,j] = button;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
