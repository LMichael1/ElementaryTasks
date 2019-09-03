using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace NumericalSequence
{
    interface ISequenceValidator : IArgsValidator
    {
        bool IsValueValid(int value);
        ArgsValidatorResult ValidateArgs();
    }
}
