using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Envelopes
{
    interface IEnvelopeValidator : IValidator
    {
        bool IsSizesValid(double length, double width);
    }
}
