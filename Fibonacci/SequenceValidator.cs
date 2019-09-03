﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Fibonacci
{
    class SequenceValidator : ArgsValidator, ISequenceValidator
    {
        public SequenceValidator(string[] args, int argsLength) : base(args, argsLength)
        {

        }

        public bool IsValuesValid(int min, int max)
        {
            return max > min;
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

            int min = Convert.ToInt32(_args[0]);
            int max = Convert.ToInt32(_args[1]);

            if (!IsValuesValid(min, max))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            return ArgsValidatorResult.Success;
        }
    }
}
