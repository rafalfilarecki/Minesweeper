using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper
{
    public class Game
    {
        public Board Board { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        private bool IsGameOver;
        private bool IsGameWon;
        public event Action<string> GameOver;

        private bool[,] initialMines;

        // TODO: Make UI prettier
        // TODO: Prevent from input errors
        // TODO: Left and right click reveals surrounding of non mine cell if all mines flagged
        public Game(int rows, int columns, int mines)
        {
            Rows = rows;
            Columns = columns;
            Board = new Board(rows, columns, mines);
            IsGameOver = false;
            IsGameWon = false;

            SaveInitialState();
        }

        public void ToggleFlag(int row, int column)
        {
            Board.Cells[row, column].ToogleFlag();
        }

        public void RevealCell(int row, int column)
        {
            if (IsGameOver)
            {
                return;
            }

            Board.RevealCell(row, column);
            CheckGameState(row, column);
        }

        public void RevealSurroundingCells(int row, int column) //TODO: return if not enough flagged cells in surrounding
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if (i <= 0 && i <= Rows && j >= 0 && j <= Columns)
                    {
                        if (!Board.Cells[i, j].IsRevealed)
                        {
                            RevealCell(i, j);
                        }
                    }
                }
            }
        }

        private void SaveInitialState()
        {
            initialMines = new bool[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    initialMines[i, j] = Board.Cells[i, j].IsMine;
                }
            }
        }

        public void Restart()
        {
            Board = new Board(Rows, Columns);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Board.Cells[i, j].IsMine = initialMines[i, j];
                }
            }
            IsGameOver = false;
            IsGameWon = false;

            Board.CalculateNeighborMines();
        }

        private void CheckGameState(int row, int column)
        {
            if (Board.Cells[row, column].IsMine && !Board.Cells[row, column].IsFlagged)
            {
                IsGameOver = true;
                RevealMines();
                GameOver?.Invoke("Game Over! You hit a mine.");
                return;
            }
            else
            {
                bool allNonMineCellsRevealed = true;
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (!Board.Cells[i, j].IsMine && !Board.Cells[i, j].IsRevealed)
                        {
                            allNonMineCellsRevealed = false;
                            break;
                        }
                    }
                    if (!allNonMineCellsRevealed)
                    {
                        break;
                    }
                }

                if (allNonMineCellsRevealed)
                {
                    IsGameWon = true;
                    IsGameOver = true;
                    GameOver?.Invoke("Congratulations! You won.");
                }
            }
        }

        private void RevealMines() // TODO: Make it visible
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Board.Cells[i, j].IsMine)
                    {
                        Board.Cells[i, j].Reaveal();
                    }
                }
            }
        }

        public int GetFlaggedCount()
        {
            int flaggedCount = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Board.Cells[i, j].IsFlagged)
                    {
                        flaggedCount++;
                    }
                }
            }

            return flaggedCount;
        }
    }
}
