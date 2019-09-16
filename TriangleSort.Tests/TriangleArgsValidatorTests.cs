using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleSort.Constants;
using Validation;
using Xunit;

namespace TriangleSort.Tests
{
    public class TriangleArgsValidatorTests
    {
        #region fields

        private ITriangleArgsValidator _validator; 

        #endregion

        public TriangleArgsValidatorTests()
        {
            string[] args = new string[0];
            _validator = new TriangleArgsValidator(args,
                NumericConstants.ARGS_LENGTH, NumericConstants.MIN_SIDE);
        }

        [Theory]
        [InlineData()]
        public void TriangleArgsValidator_WithStringArgs_ShouldReturnEmpty(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Empty, result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("a", "b")]
        [InlineData("a", "1", "3")]
        public void TriangleArgsValidator_WithStringArgs_ShouldReturnInvalidNumberOfArgs(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidNumberOfArgs, result);
        }

        [Theory]
        [InlineData("name1", "a", "b", "c")]
        [InlineData("name2", "b", "1,0", "2,0")]
        [InlineData("name3", "1.0", "3.0", "g")]
        public void TriangleArgsValidator_WithStringArgs_ShouldReturnInvalidTypeOfArgs(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidTypeOfArgs, result);
        }

        [Theory]
        [InlineData("name1", "0,0", "5,0", "5,0")]
        [InlineData("name2", "-5,2", "1,0", "2,0")]
        [InlineData("name3", "2", "3", "5")]
        public void TriangleArgsValidator_WithStringArgs_ShouldReturnInvalidValue(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidValue, result);
        }

        [Theory]
        [InlineData("name1", "1", "1,7", "1")]
        [InlineData("name2", "5", "6", "7")]
        [InlineData("name3", "3,2", "3,3", "2,1")]
        public void TriangleArgsValidator_WithStringArgs_ShouldReturnSuccess(params string[] args)
        {
            _validator.Args = args;
            var result = _validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Success, result);
        }
    }
}
