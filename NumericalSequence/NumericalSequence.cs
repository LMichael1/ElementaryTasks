using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSequence
{
    class NumericalSequence : IEnumerable<int>
    {
        #region Fields

        private int _maxNumber;

        #endregion

        public int this[int index]
        {
            get
            {
                if (index < _maxNumber)
                {
                    return index + 1;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public NumericalSequence(int n)
        {
            _maxNumber = GetMaxNumber(n);
        }

        private int GetMaxNumber(int n)
        {
            int count = (int)Math.Sqrt(n);

            if (Math.Pow(count, 2) == n)
            {
                count --;
            }

            return count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NumericalSequenceEnumerator(_maxNumber);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NumericalSequenceEnumerator(_maxNumber);
        }
    }
}
