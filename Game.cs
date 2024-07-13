using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
