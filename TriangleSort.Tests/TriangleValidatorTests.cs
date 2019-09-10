using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TriangleSort.Tests
{
    public class TriangleValidatorTests
    {
        [Theory]
        [InlineData(10.0, 11.0, 15.0)]
        [InlineData(5.0, 5.0, 5.0)]
        [InlineData(126.0, 418.0, 364.0)]
        public void TriangleExists(double firstSide, double secondSide, double thirdSide)
        {
            Assert.True(TriangleValidator.IsTriangleExists(firstSide, secondSide, thirdSide));
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(2.0, 3.0, 6.0)]
        [InlineData(444.0, 536.0, 1151.0)]
        public void TriangleDoesntExists(double firstSide, double secondSide, double thirdSide)
        {
            Assert.False(TriangleValidator.IsTriangleExists(firstSide, secondSide, thirdSide));
        }
    }
}
