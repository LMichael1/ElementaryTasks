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
        private readonly int _argsLengthForRange;

        #endregion

        public SequenceArgsValidator(string[] args, int argsLength, 
            int argsLengthForRange, int minValue) : base (args, argsLength)
        {
            _minValue = minValue;
            _argsLengthForRange = argsLengthForRange;
        }

        public override bool IsNumberOfArgsValid()
        {
            return Args.Length == _argsLength || Args.Length == _argsLengthForRange;
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

            foreach (var arg in Args)
            {
                int value = Convert.ToInt32(arg);

                if (!IsValueValid(value))
                {
                    return ArgsValidatorResult.InvalidValue;
                }
            }

            return ArgsValidatorResult.Success;
        }
    }
}
