using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    interface IBoard
    {
        int NumberOfRows { get; }
        int NumberOfColumns { get; }
        Piece GetPiece(int row, int column);
        Cell GetCell(int row, int column);
    }
}
