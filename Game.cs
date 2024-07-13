﻿using System;
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

        public Game(int rows, int columns, int mines)
        {
            Rows = rows;
            Columns = columns;
            Board = new Board(rows, columns, mines);
            IsGameOver = false;
            IsGameWon = false;
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

        private void CheckGameState(int row, int column)
        {
            if (Board.Cells[row, column].IsMine)
            {
                IsGameOver = true;
                MessageBox.Show("Game Over! You hit a mine.");
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
                    MessageBox.Show("Congratulations! You won.");
                }
            }
        }
    }
}
