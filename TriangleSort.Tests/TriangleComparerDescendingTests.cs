using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TriangleSort.Tests
{
    public class TrinagleComparerDescendingTests
    {
        [Theory]
        [InlineData("name", 10.0, 10.0, 10.0, "name", 10.0, 10.0, 10.0)]
        [InlineData("name", 1.0, 1.0, 1.0, "name", 1.0, 1.0, 1.0)]
        [InlineData("name", 120.0, 120.0, 120.0, "name", 120.0, 120.0, 120.0)]
        public void Compare_Triangles_ReturnsEqual(string name1, double firstSide1, double secondSide1, double thirdSide1,
            string name2, double firstSide2, double secondSide2, double thirdSide2)
        {
            Triangle first = new Triangle(name1, firstSide1, secondSide1, thirdSide1);
            Triangle second = new Triangle(name2, firstSide2, secondSide2, thirdSide2);

            Assert.Equal(0, new TriangleComparerDescending().Compare(first, second));
        }

        [Theory]
        [InlineData("name1", 10.0, 10.0, 10.0, "name2", 11.0, 10.0, 10.0)]
        [InlineData("name1", 0.5, 1.0, 1.0, "name2", 1.0, 1.0, 1.0)]
        [InlineData("name1", 110.0, 120.0, 120.0, "name2", 120.0, 120.0, 120.0)]
        public void Compare_Triangles_ReturnsLess(string name1, double firstSide1, double secondSide1, double thirdSide1,
            string name2, double firstSide2, double secondSide2, double thirdSide2)
        {
            Triangle first = new Triangle(name1, firstSide1, secondSide1, thirdSide1);
            Triangle second = new Triangle(name2, firstSide2, secondSide2, thirdSide2);

            Assert.Equal(1, new TriangleComparerDescending().Compare(first, second));
        }

        [Theory]
        [InlineData("name1", 11.0, 10.0, 10.0, "name2", 10.0, 10.0, 10.0)]
        [InlineData("name1", 2.0, 1.2, 1.0, "name2", 1.0, 1.0, 1.0)]
        [InlineData("name1", 25.0, 16.0, 10.0, "name2", 1.0, 1.0, 1.0)]
        public void CompareTriangles_ReturnsBigger(string name1, double firstSide1, double secondSide1, double thirdSide1,
            string name2, double firstSide2, double secondSide2, double thirdSide2)
        {
            Triangle first = new Triangle(name1, firstSide1, secondSide1, thirdSide1);
            Triangle second = new Triangle(name2, firstSide2, secondSide2, thirdSide2);

            Assert.Equal(-1, new TriangleComparerDescending().Compare(first, second));
        }
    }
}
