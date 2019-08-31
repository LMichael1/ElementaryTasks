using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Cell
    {
        #region Properties

        public bool IsOccupied { get; set; }
        public int Row { get; }
        public int Column { get; }
        public CellColor Color { get; }

        #endregion

        public Cell(int y, int x)
        {
            Row = y;
            Column = x;
            IsOccupied = false;

            if ((Row % 2 == 0 && Column % 2 == 0) || (Row % 2 != 0 && Column % 2 != 0))
            {
                Color = CellColor.White;
            }
            else
            {
                Color = CellColor.Black;
            }
        }
    }
}
