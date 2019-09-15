using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NumericalSequence.Tests
{
    public class NumericalSequenceEnumeratorTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(7, 9)]
        [InlineData(15, 16)]
        public void PropertyObjectCurrent_WithStartAndMaxNumber_ShouldReturnMax(int start, int max)
        {
            IEnumerator enumerator = new NumericalSequenceEnumerator(start, max);
           
            for (int i = start; i < max; i++)
            {
                enumerator.MoveNext();
            }

            Assert.Equal(max, enumerator.Current);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(7, 9)]
        [InlineData(15, 16)]
        public void PropertyIntCurrent_WithStartAndMaxNumber_ShouldReturnMax(int start, int max)
        {
            NumericalSequenceEnumerator enumerator = new NumericalSequenceEnumerator(start, max);

            for (int i = start; i < max; i++)
            {
                enumerator.MoveNext();
            }

            Assert.Equal(max, enumerator.Current);
        }
    }
}
