using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Envelopes
{
    interface IEnvelopeArgsValidator : IArgsValidator
    {
        bool IsSizesValid(double length, double width);
        ArgsValidatorResult ValidateArgs();
        ArgsValidatorResult ValidateEnvelope(string length, string width);
    }
}
