using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Triangles
{
    interface ITriangleValidator : IArgsValidator
    {
        bool IsSizesValid(double firstSide, double secondSide, double thirdSide);
        ArgsValidatorResult ValidateArgs();
    }
}
