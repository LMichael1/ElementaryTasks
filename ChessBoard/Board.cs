using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Board : IBoard
    {
        #region Private fields

        private Cell[,] _cells;
        private List<Piece> _pieces;

        #endregion

        #region Constants

        public const int FREE_ROWS_EVEN = 2;
        public const int FREE_ROWS_ODD = 3;

        #endregion

        #region Properties

        public int NumberOfRows
        {
            get
            {
                return _cells.GetLength(0);
            }
        }

        public int NumberOfColumns
        {
            get
            {
                return _cells.GetLength(1);
            }
        }

        public int NumberOfWhitePieces
        {
            get
            {
                return _pieces.Where(piece => piece.Color == PieceColor.White).Count();
            }
        }

        public int NumberOfBlackPieces
        {
            get
            {
                return _pieces.Where(piece => piece.Color == PieceColor.Black).Count();
            }
        } 

        #endregion

        public Board(int height, int width)
        {
            _cells = new Cell[height, width];
            _pieces = new List<Piece>();

            InitCells();
            SetUpPieces();
        }

        private void InitCells()
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
        }

        private void SetUpPieces()
        {
            int freeRowsBetweenPieces = FREE_ROWS_EVEN;

            if (_cells.GetLength(0) % 2 != 0)
            {
                freeRowsBetweenPieces = FREE_ROWS_ODD;
            }

            int start = 1;
            for (int i = (NumberOfRows - freeRowsBetweenPieces) / 2 - 1; i >= 0; i--)
            {
                for (int j = start; j < NumberOfColumns; j += 2)
                {
                    _pieces.Add(new Piece(_cells[i, j], PieceColor.White));
                }

                start = start == 1 ? 0 : 1;
            }

            for (int i = NumberOfRows - (NumberOfRows - freeRowsBetweenPieces) / 2; i < NumberOfRows; i++)
            {
                for (int j = start; j < NumberOfColumns; j += 2)
                {
                    _pieces.Add(new Piece(_cells[i, j], PieceColor.Black));
                }

                start = start == 1 ? 0 : 1;
            }
        }

        public bool RemovePiece(int row, int column)
        {
            Piece toRemove = GetPiece(row, column);
            bool result = false;

            if (toRemove != null)
            {
                _cells[row, column].IsOccupied = false;
                _pieces.Remove(toRemove);
                result = true;
            }

            return result;
        }

        public Piece GetPiece(int row, int column)
        {
            var selected = _pieces.FirstOrDefault
                (item => item.Position.Row == row && item.Position.Column == column);

            return selected;
        }

        public Cell GetCell(int row, int column)
        {
            Cell result = null;

            if ((row >= 0 && row < NumberOfRows) && (column >= 0 && column < NumberOfColumns))
            {
                result = _cells[row, column];
            }

            return result;
        }
    }
}
