using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Envelopes
{
    class EnvelopeValidator : Validator, IEnvelopeValidator
    {
        #region Fields

        private readonly double _minLength;
        private readonly double _minWidth;

        #endregion

        public EnvelopeValidator(int argsLength, double minLength, double minWidth) : base(argsLength)
        {
            _minLength = minLength;
            _minWidth = minWidth;
        }

        public override bool IsNumber(string number)
        {
            return double.TryParse(number, out _);
        }

        public bool IsSizesValid(double length, double width)
        {
            return (length >= _minLength) && (width >= _minWidth);
        }
    }
}
