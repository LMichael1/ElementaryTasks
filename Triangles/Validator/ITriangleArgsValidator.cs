using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace TriangleSort
{
    public interface ITriangleArgsValidator : IArgsValidator
    {
        ArgsValidatorResult ValidateArgs();
    }
}
