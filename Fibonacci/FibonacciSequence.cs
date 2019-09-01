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

        private int _x;
        private int _y;
        private int _z;

        #endregion

        public int this[int index]
        {
            get
            {
                if (index < this.Count())
                {
                    return this.ToList()[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public FibonacciSequence(int minNumber, int maxNumber)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;

            FindFirstFibonacci();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new FibonacciEnumerator(_maxNumber, _x, _y, _z);
        }

        private void FindFirstFibonacci()
        {
            _x = 0;
            _y = 1;
            _z = 0;
            while (_x + _y < _minNumber)
            {
                _z = _x + _y;
                _x = _y;
                _y = _z;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FibonacciEnumerator(_maxNumber, _x, _y, _z);
        }

        public override string ToString()
        {
            return string.Join(", ", this.ToList());
        }
    }
}
