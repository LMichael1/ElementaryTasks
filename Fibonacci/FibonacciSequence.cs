using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class FibonacciSequence : IEnumerable<int>
    {
        #region Private fields

        private int _minNumber;
        private int _maxNumber;

        #endregion

        public FibonacciSequence(int minNumber, int maxNumber)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new FibonacciEnumerator(_minNumber, _maxNumber);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FibonacciEnumerator(_minNumber, _maxNumber);
        }
    }
}
