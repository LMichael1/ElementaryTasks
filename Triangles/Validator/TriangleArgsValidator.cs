﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleSort.Constants;
using Validation;

namespace TriangleSort
{
    public class TriangleArgsValidator : ArgsValidator, ITriangleArgsValidator
    {
        #region Fields

        private readonly double _minSide;

        #endregion

        public TriangleArgsValidator(string[] args, int argsLength, double minSide) : base(args, argsLength)
        {
            _minSide = minSide;
        }

        private bool IsSizesValid(params double[] sizes)
        {
            bool result = true;

            foreach (var s in sizes)
            {
                if (s <= _minSide)
                {
                    result = false;
                    break;
                }
            }

            return result;
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

            if (!IsDoubles(Args[1], Args[2], Args[3]))
            {
                return ArgsValidatorResult.InvalidTypeOfArgs;
            }

            double firstSide = Convert.ToDouble(Args[1]);
            double secondSide = Convert.ToDouble(Args[2]);
            double thirdSide = Convert.ToDouble(Args[3]);

            if (!IsSizesValid(firstSide, secondSide, thirdSide))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            if (!TriangleValidator.IsTriangleExists(firstSide, secondSide, thirdSide))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            return ArgsValidatorResult.Success;
        }
    }
}
