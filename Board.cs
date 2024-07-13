using System;
using System.Windows.Controls.Primitives;

namespace Minesweeper
{
    public class Board
    {
        private readonly int Rows;
        private readonly int Columns;
        private readonly int Mines;
        public Cell[,] Cells { get; private set; }

        public Board(int rows, int columns, int mines)
        {
            Rows = rows;
            Columns = columns;
            Mines = mines;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Cells = new Cell[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
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

            while (minesPlaced < Mines)
            {
                int i = random.Next(Rows);
                int j = random.Next(Columns);

                if (!Cells[i, j].IsMine)
                {
                    Cells[i,j].IsMine = true;
                    minesPlaced++;
                }
            }
        }

        private void CalculateNeighborMines()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
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
                for (int j = -1; j <= 1; j++)
                {
                    int r = row + i;
                    int c = column + j;
                    if (r >= 0 && r < Rows && c >= 0 && c < Columns && Cells[r, c].IsMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void RevealCell(int row, int column)
        {
            if (Cells[row, column].IsRevealed || Cells[row, column].IsFlagged)
            {
                return;
            }

            Cells[row, column].Reaveal();

            if (Cells[row, column].NeighborMines == 0 && !Cells[row, column].IsMine)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int r = row + i;
                        int c = column + j;
                        if (r >= 0 && r < Rows && c >= 0 && c < Columns && !Cells[r, c].IsRevealed)
                        {
                            RevealCell(r, c);
                        }
                    }
                }
            }
        }
    }
}
