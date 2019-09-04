using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Envelopes
{
    class EnvelopeValidator : ArgsValidator, IEnvelopeValidator
    {
        #region Fields

        private readonly double _minLength;
        private readonly double _minWidth;

        #endregion

        public EnvelopeValidator(string[] args, int argsLength, double minLength, double minWidth) : base(args, argsLength)
        {
            _minLength = minLength;
            _minWidth = minWidth;
        }

        public bool IsSizesValid(double length, double width)
        {
            return (length >= _minLength) && (width >= _minWidth);
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

            if (!IsArgsDoubles())
            {
                return ArgsValidatorResult.InvalidTypeOfArgs;
            }

            double length = Convert.ToDouble(Args[0]);
            double width = Convert.ToDouble(Args[1]);

            if (!IsSizesValid(length, width))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            return ArgsValidatorResult.Success;
        }

        public ArgsValidatorResult ValidateEnvelope(string length, string width)
        {
            if (!IsDoubles(length) || !IsDoubles(width))
            {
                return ArgsValidatorResult.InvalidTypeOfArgs;
            }

            double envelopeLength = Convert.ToDouble(length);
            double envelopeWidth = Convert.ToDouble(width);

            if (!IsSizesValid(envelopeLength, envelopeWidth))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            return ArgsValidatorResult.Success;
        }
    }
}
