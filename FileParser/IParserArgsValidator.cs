using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace FileParser
{
    interface IParserArgsValidator : IArgsValidator
    {
        ArgsValidatorResult ValidateArgs();
    }
}
