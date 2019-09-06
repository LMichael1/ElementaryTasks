using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace ChessBoard
{
    class BoardArgsValidator : ArgsValidator, IBoardArgsValidator
    {
        #region Fields

        private readonly int _minNumberOfRows;
        private readonly int _minNumberOfColumns;

        #endregion

        public BoardArgsValidator (string[] args, int argsLength, int minNumberOfRows, int minNumberOfColumns) : base (args, argsLength)
        {
            _minNumberOfRows = minNumberOfRows;
            _minNumberOfColumns = minNumberOfColumns;
        }

        public bool IsSizesValid(int rows, int columns)
        {
            return (rows >= _minNumberOfRows) && (columns >= _minNumberOfColumns);
        }

        public ArgsValidatorResult ValidateArgs()
        {
            if (IsArgsEmpty())
            {
                return ArgsValidatorResult.Empty;
            }

            if (!IsNumberOfArgsValid())
            {
                return ArgsValidatorResult.InvalidNumberOfArgs;
            }

            if (!IsArgsIntegers())
            {
                return ArgsValidatorResult.InvalidTypeOfArgs;
            }

            int rows = Convert.ToInt32(Args[0]);
            int columns = Convert.ToInt32(Args[1]);

            if (!IsSizesValid(rows, columns))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            return ArgsValidatorResult.Success;
        }
    }
}
