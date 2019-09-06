using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace ChessBoard
{
    interface IBoardArgsValidator : IArgsValidator
    {
        bool IsSizesValid(int rows, int columns);
        ArgsValidatorResult ValidateArgs();
    }
}
