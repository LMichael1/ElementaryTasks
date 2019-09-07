using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace NumericIntoWords
{
    class NumericArgsValidator : ArgsValidator, INumericArgsValidator
    {
        public NumericArgsValidator(string[] args, int argsLength) : base(args, argsLength)
        {

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

            return ArgsValidatorResult.Success;
        }
    }
}
