using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace NumericalSequence
{
    public interface ISequenceArgsValidator : IArgsValidator
    {
        bool IsValueValid(int value);
        ArgsValidatorResult ValidateArgs();
    }
}
