using NumericalSequence.Constants;
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
        private SequenceArgsValidator _validator;

        public SequenceArgsValidatorTests()
        {
            string[] args = new string[0];
            _validator = new SequenceArgsValidator(args, NumericConstants.ARGS_LENGTH,
                NumericConstants.ARGS_LENGTH_FOR_RANGE, NumericConstants.MIN_VALUE);
        }

        [Theory]
        [InlineData()]
        public void SequenceArgsValidator_WithStringArgs_ShouldReturnEmpty(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Empty, result);
        }

        [Theory]
        [InlineData("1", "2", "3")]
        [InlineData("1", "2", "3", "4")]
        [InlineData("1", "2", "3", "4", "5")]
        public void SequenceArgsValidator_WithStringArgs_ShouldReturnInvalidNumberOfArgs(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidNumberOfArgs, result);
        }

        [Theory]
        [InlineData("1,3")]
        [InlineData("string")]
        [InlineData("1.5")]
        public void SequenceArgsValidator_WithStringArgs_ShouldReturnInvalidTypeOfArgs(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidTypeOfArgs, result);
        }

        [Theory]
        [InlineData("-2")]
        [InlineData("-1")]
        [InlineData("1")]
        public void SequenceArgsValidator_WithStringArgs_ShouldReturnInvalidValue(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidValue, result);
        }

        [Theory]
        [InlineData("2")]
        [InlineData("173")]
        [InlineData("23213")]
        public void SequenceArgsValidator_WithStringArgs_ShouldReturnSuccess(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Success, result);
        }
    }
}
