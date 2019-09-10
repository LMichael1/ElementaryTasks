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
        [Fact]
        public void TestSequenceInRange()
        {
            NumericalSequence sequence = new NumericalSequence(25);
            int[] s = sequence.ToArray();
            int[] s1 = { 1, 2, 3, 4 };
            Assert.Equal(s, s1);
        }
    }
}
