using System;
using System.Windows.Controls.Primitives;

namespace Minesweeper
{
    public class Board
    {
        private readonly int rows;
        private readonly int columns;
        private readonly int mines;
        public Cell[,] Cells { get; private set; }

        public Board(int rows, int columns, int mines)
        {
            this.rows = rows;
            this.columns = columns;
            this.mines = mines;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Cells = new Cell[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }

            PlaceMines();
            CalculateNeighborMines();
        }

        private void PlaceMines()
        {
            Random random = new Random();
            int minesPlaced = 0;

            while (minesPlaced < mines)
            {
                int i = random.Next(rows);
                int j = random.Next(columns);

                if (!Cells[i, j].IsMine)
                {
                    Cells[i,j].IsMine = true;
                    minesPlaced++;
                }
            }
        }

        private void CalculateNeighborMines()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!Cells[i, j].IsMine)
                    {
                        Cells[i, j].NeighborMines = CountNeighborMines(i, j);
                    }
                }
            }
        }

        private int CountNeighborMines(int row, int column)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j =-1; j <= 1; j++)
                {
                    int r = row + i;
                    int c = column + j;
                    if (r >= 0 && r < rows && c >= 0 && c < columns && Cells[r, c].IsMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}
