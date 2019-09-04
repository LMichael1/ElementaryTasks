using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Triangles
{
    class TriangleValidator : ArgsValidator, ITriangleValidator
    {
        #region Properties

        private readonly double _minSide;

        #endregion

        public TriangleValidator(string[] args, int argsLength, double minSide) : base(args, argsLength)
        {
            _minSide = minSide;
        }

        public bool IsSizesValid(double firstSide, double secondSide, double thirdSide)
        {
            bool result = false;

            List<double> sides = new List<double> { firstSide, secondSide, thirdSide };
            sides.Sort();

            if ((firstSide >= _minSide && secondSide >= _minSide && thirdSide >= _minSide)
                && (sides[0] + sides[1] > sides[2]))
            {
                result = true;
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

            return ArgsValidatorResult.Success;
        }
    }
}
