using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Fibonacci
{
    interface ISequenceValidator : IArgsValidator
    {
        bool IsValuesValid(int min, int max);
        ArgsValidatorResult ValidateArgs();
    }
}
