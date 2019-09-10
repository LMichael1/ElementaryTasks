using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace NumericalSequence
{
    public class SequenceArgsValidator : ArgsValidator, ISequenceArgsValidator
    {
        #region Private fields

        private readonly int _minValue; 

        #endregion

        public SequenceArgsValidator(string[] args, int argsLength, int minValue) : base (args, argsLength)
        {
            _minValue = minValue;
        }

        public bool IsValueValid(int value)
        {
            return value >= _minValue;
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

            int value = Convert.ToInt32(Args[0]);

            if (!IsValueValid(value))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            return ArgsValidatorResult.Success;
        }
    }
}
