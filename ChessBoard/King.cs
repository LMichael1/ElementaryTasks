using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class King : Piece
    {
        public King(Cell place, PieceColor color) : base(place, color)
        {

        }

        public King(Piece basePiece) : base(basePiece.Position, basePiece.Color)
        {

        }

        public override bool CanBeMovedTo(Cell target)
        {
            return (!target.IsOccupied) &&
                (Math.Abs(target.Row - Position.Row) == Math.Abs(target.Column - Position.Column));
        }
    }
}
