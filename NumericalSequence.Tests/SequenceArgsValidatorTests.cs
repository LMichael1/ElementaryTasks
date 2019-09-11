using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using Xunit;

namespace NumericalSequence.Tests
{
    public class SequenceArgsValidatorTests
    {
        [Theory]
        [InlineData()]
        public void Validate_Args_ReturnsEmpty(params string[] args)
        {
            ISequenceArgsValidator validator = new SequenceArgsValidator(args, 1, 2, 2);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Empty, result);
        }

        [Theory]
        [InlineData("1", "2", "3")]
        [InlineData("1", "2", "3", "4")]
        [InlineData("1", "2", "3", "4", "5")]
        public void Validate_Args_ReturnsInvalidNumber(params string[] args)
        {
            ISequenceArgsValidator validator = new SequenceArgsValidator(args, 1, 2, 2);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidNumberOfArgs, result);
        }

        [Theory]
        [InlineData("1,3")]
        [InlineData("string")]
        [InlineData("1.5")]
        public void Validate_Args_ReturnsInvalidType(params string[] args)
        {
            ISequenceArgsValidator validator = new SequenceArgsValidator(args, 1, 2, 2);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidTypeOfArgs, result);
        }

        [Theory]
        [InlineData("-2")]
        [InlineData("-1")]
        [InlineData("1")]
        public void Validate_Args_ReturnsInvalidValue(params string[] args)
        {
            ISequenceArgsValidator validator = new SequenceArgsValidator(args, 1, 2, 2);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidValue, result);
        }

        [Theory]
        [InlineData("2")]
        [InlineData("173")]
        [InlineData("23213")]
        public void Validate_Args_ReturnsValid(params string[] args)
        {
            ISequenceArgsValidator validator = new SequenceArgsValidator(args, 1, 2, 2);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Success, result);
        }
    }
}
