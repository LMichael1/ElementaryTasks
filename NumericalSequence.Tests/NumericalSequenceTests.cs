using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NumericalSequence;

namespace NumericalSequence.Tests
{
    public class NumericalSequenceTests
    {
        [Theory]
        [InlineData(5, 81, 5, 6, 7, 8)]
        [InlineData(2, 9, 2)]
        [InlineData(12, 225, 12, 13, 14)]
        [InlineData(1, 67, 1, 2, 3, 4, 5, 6, 7, 8)]
        [InlineData(2, 10, 2, 3)]
        public void NumericalSequence_WithMinNumberAndMaxSquare_ShouldReturnSequence(int minSquare, int maxSquare, params int[] expected)
        {
            NumericalSequence sequence = new NumericalSequence(minSquare, maxSquare);
            int[] array = sequence.ToArray();

            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(5, 1, 2)]
        [InlineData(16, 1, 2, 3)]
        [InlineData(2, 1)]
        public void NumericalSequence_WithMaxSquare_ShouldReturnSequence(int maxSquare, params int[] expected)
        {
            NumericalSequence sequence = new NumericalSequence(maxSquare);
            int[] array = sequence.ToArray();

            Assert.Equal(expected, array);
        }
    }
}
