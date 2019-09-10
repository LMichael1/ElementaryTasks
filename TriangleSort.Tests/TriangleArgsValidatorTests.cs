using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using Xunit;

namespace TriangleSort.Tests
{
    public class TriangleArgsValidatorTests
    {
        [Theory]
        [InlineData()]
        public void ArgsEmpty(params string[] args)
        {
            ITriangleArgsValidator validator = new TriangleArgsValidator(args, 4, 0.0);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Empty, result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("a", "b")]
        [InlineData("a", "1", "3")]
        public void InvalidNumberOfArgs(params string[] args)
        {
            ITriangleArgsValidator validator = new TriangleArgsValidator(args, 4, 0.0);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidNumberOfArgs, result);
        }

        [Theory]
        [InlineData("name1", "a", "b", "c")]
        [InlineData("name2", "b", "1,0", "2,0")]
        [InlineData("name3", "1.0", "3.0", "g")]
        public void InvalidTypeOfArgs(params string[] args)
        {
            ITriangleArgsValidator validator = new TriangleArgsValidator(args, 4, 0.0);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidTypeOfArgs, result);
        }

        [Theory]
        [InlineData("name1", "0,0", "5,0", "5,0")]
        [InlineData("name2", "-5,2", "1,0", "2,0")]
        [InlineData("name3", "2", "3", "5")]
        public void InvalidSizes(params string[] args)
        {
            ITriangleArgsValidator validator = new TriangleArgsValidator(args, 4, 0.0);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.InvalidValue, result);
        }

        [Theory]
        [InlineData("name1", "1", "1,7", "1")]
        [InlineData("name2", "5", "6", "7")]
        [InlineData("name3", "3,2", "3,3", "2,1")]
        public void ValidArgs(params string[] args)
        {
            ITriangleArgsValidator validator = new TriangleArgsValidator(args, 4, 0.0);
            ArgsValidatorResult result = validator.ValidateArgs();

            Assert.Equal(ArgsValidatorResult.Success, result);
        }
    }
}
