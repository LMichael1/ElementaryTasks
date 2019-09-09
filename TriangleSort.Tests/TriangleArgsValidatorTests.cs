using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Validation;
using Xunit;

namespace TriangleSort.Tests
{
    public class TriangleArgsValidatorTests
    {
        [Theory]
        [InlineData(new string[] { "test", "1,0", "2,0", "2,0"}, 4, 0.0)]
        [InlineData(new string[] { "test", "5,0", "4,0", "2,0" }, 4, 0.0)]
        [InlineData(new string[] { "test", "123,2", "51,1", "83,7" }, 4, 0.0)]
        public void SizesValid(string[] args, int argsLength, double minSide)
        {
            ITriangleArgsValidator validator = new TriangleArgsValidator(args, argsLength, minSide);

            double firstSide = Convert.ToDouble(args[1]);
            double secondSide = Convert.ToDouble(args[2]);
            double thirdSide = Convert.ToDouble(args[3]);

            Type testType = validator.GetType();
            var method = testType.GetMethod("IsSizesValid", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)method.Invoke(validator, new object[] { new double[] { firstSide, secondSide, thirdSide } });

            Assert.True(result);
        }

        [Theory]
        [InlineData(new string[] { "test", "0,0", "2,0", "2,0" }, 4, 0.0)]
        [InlineData(new string[] { "test", "5,0", "-4,0", "2,0" }, 4, 0.0)]
        [InlineData(new string[] { "test", "123,2", "51,1", "-83,7" }, 4, 0.0)]
        public void SizesInvalid(string[] args, int argsLength, double minSide)
        {
            ITriangleArgsValidator validator = new TriangleArgsValidator(args, argsLength, minSide);

            double firstSide = Convert.ToDouble(args[1]);
            double secondSide = Convert.ToDouble(args[2]);
            double thirdSide = Convert.ToDouble(args[3]);

            Type testType = validator.GetType();
            var method = testType.GetMethod("IsSizesValid", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)method.Invoke(validator, new object[] { new double[] { firstSide, secondSide, thirdSide } });

            Assert.False(result);
        }
    }
}
