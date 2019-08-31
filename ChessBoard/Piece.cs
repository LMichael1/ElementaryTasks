using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Piece
    {
        #region Properties

        public Cell Position { get; set; }
        public PieceColor Color { get; }

        #endregion

        public Piece(Cell place, PieceColor player)
        {
            Position = place;
            Color = player;

            place.IsOccupied = true;
        }

        public virtual bool CanBeMovedTo(Cell target)
        {
            return (!target.IsOccupied) && (target.Row > Position.Row) &&
                (target.Column == Position.Column + 1 || target.Column == Position.Column - 1);
        }
    }
}
