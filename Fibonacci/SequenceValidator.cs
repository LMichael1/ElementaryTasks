using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Fibonacci
{
    class SequenceValidator : Validator, ISequenceValidator
    {
        public SequenceValidator(int argsLength) : base(argsLength)
        {

        }

        public bool IsValuesValid(int min, int max)
        {
            return max > min;
        }
    }
}
