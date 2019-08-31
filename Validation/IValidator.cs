using System;
using System.Collections.Generic;
using System.Text;

namespace Validation
{
    public interface IValidator
    {
        bool IsNumber(string number);
        bool IsNumberOfArgsValid(string[] args);
        bool IsArgsNumbers(params string[] args);
        bool IsArgsEmpty(string[] args);
    }
}
