using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper
{
    public partial class GameWindow : Window
    {
        private Game Game;
        private Button[,] Buttons;
        private int initialRows;
        private int initialColumns;
        private int initialMines;

        public GameWindow(int rows, int columns, int mines)
        {
            InitializeComponent();
            initialRows = rows;
            initialColumns = columns;
            initialMines = mines;
            StartNewGame(rows, columns, mines);
        }

        private void StartNewGame(int rows, int columns, int mines)
        {
            Game = new Game(rows, columns, mines);
            InitializeGrid(rows, columns);
            Game.GameOver += OnGameOver;
        }

        private void InitializeGrid(int rows, int columns)
        {
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < rows; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
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
                    button.MouseRightButtonDown += Button_MouseRightButtonDown;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    GameGrid.Children.Add(button);
                    Buttons[i,j] = button;
                }
            }

            UpdateGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int[] position = button.Tag as int[];
            int row = position[0];
            int column = position[1];

            Game.RevealCell(row, column);
            UpdateGrid();
        }

        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            int[] position = button.Tag as int[];
            int row = position[0];
            int column = position[1];

            Game.ToggleFlag(row, column);
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            for (int i = 0; i < Game.Rows; i++)
            {
                for (int j = 0;j < Game.Columns; j++)
                {
                    var cell = Game.Board.Cells[i, j];
                    var button = Buttons[i, j];

                    switch (true)
                    {
                        case true when (cell.IsRevealed && !cell.IsMine && cell.NeighborMines == 0):
                            button.Content = "";
                            button.IsEnabled = false;
                            break;

                        case true when cell.IsRevealed:
                            button.Content = cell.IsMine ? "M" : cell.NeighborMines.ToString();
                            button.IsEnabled = false;
                            break;

                        case true when cell.IsFlagged:
                            button.Content = "F";
                            break;

                        default:
                            button.Content = "";
                            break;
                    }
                }
            }
        }

        private void OnGameOver(string message)
        {
            GameOverWindow gameOverWindow = new GameOverWindow(message);
            bool? result = gameOverWindow.ShowDialog();

            if (result == true)
            {
                StartNewGame(initialRows, initialColumns, initialMines);
            }
            else if (result == false)
            {
                RestartCurrentGame();
            }
        }

        private void RestartCurrentGame()
        {
            Game.Restart();
            InitializeGrid(initialRows, initialColumns);
        }
    }
}
