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
        public void PropertyObjectCurrent_WithStartAndMaxNumber_ShouldReturnMax(int start, int finish)
        {
            IEnumerator enumerator = new NumericalSequenceEnumerator(start, finish);

            bool result = true;
            int i = start + 1;

            while (enumerator.MoveNext() && result)
            {
                result = ((int)enumerator.Current == i++);
            }

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(7, 9)]
        [InlineData(15, 16)]
        public void PropertyIntCurrent_WithStartAndMaxNumber_ShouldReturnMax(int start, int finish)
        {
            IEnumerator<int> enumerator = new NumericalSequenceEnumerator(start, finish);

            bool result = true;
            int i = start + 1;

            while (enumerator.MoveNext() && result)
            {
                result = (enumerator.Current == i++);
            }

            Assert.True(result);
        }
    }
}
