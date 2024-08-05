using System;

namespace Minesweeper
{
    public class Cell
    {
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public int NeighborMines { get; set; }

        public void Reaveal()
        {
            if (!IsFlagged)
            {
                IsRevealed = true;
            }
        }

        public void ToogleFlag()
        {
            if (!IsRevealed)
            {
                IsFlagged = !IsFlagged;
            }
        }
    }
}
