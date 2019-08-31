using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace ChessBoard
{
    class BoardValidator : Validator, IBoardValidator
    {
        #region Fields

        private readonly int _minNumberOfRows;
        private readonly int _minNumberOfColumns;

        #endregion

        public BoardValidator (int argsLength, int minNumberOfRows, int minNumberOfColumns) : base (argsLength)
        {
            _minNumberOfRows = minNumberOfRows;
            _minNumberOfColumns = minNumberOfColumns;
        }

        public bool IsSizesValid(int rows, int columns)
        {
            return (rows >= _minNumberOfRows) && (columns >= _minNumberOfColumns);
        }

    }
}
