using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace NumericalSequence
{
    class SequenceValidator : Validator, ISequenceValidator
    {
        #region Private fields

        private readonly int _minValue; 

        #endregion

        public SequenceValidator(int argsLength, int minValue) : base (argsLength)
        {
            _minValue = minValue;
        }

        public bool IsValueValid(int value)
        {
            return value >= _minValue;
        }
    }
}
