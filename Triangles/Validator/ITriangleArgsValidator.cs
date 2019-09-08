using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace TriangleSort
{
    interface ITriangleArgsValidator : IArgsValidator
    {
        bool IsSizesValid(params double[] sizes);
        ArgsValidatorResult ValidateArgs();
    }
}
