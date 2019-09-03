using System;
using System.Collections.Generic;
using System.Text;

namespace Validation
{
    public interface IArgsValidator
    {
        bool IsInteger(int argIndex);
        bool IsDouble(int argIndex);
        bool IsNumberOfArgsValid();
        bool IsArgsEmpty();
        bool IsArgsIntegers();
        bool IsArgsDoubles();
    }
}
