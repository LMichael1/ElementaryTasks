using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSequence
{
    public class NumericalSequence : IEnumerable<int>
    {
        #region Fields

        private int _minNumber;
        private int _maxNumber;

        #endregion

        public NumericalSequence(int maxSquare)
        {
            _minNumber = 1;
            _maxNumber = GetMaxNumber(maxSquare);
        }

        public NumericalSequence(int minSquare, int maxSquare)
        {
            _minNumber = GetMinNumber(minSquare);
            _maxNumber = GetMaxNumber(maxSquare);
        }

        private int GetMaxNumber(int n)
        {
            int number = (int)Math.Sqrt(n);

            if (Math.Pow(number, 2) == n)
            {
                number--;
            }

            return number;
        }

        private int GetMinNumber(int n)
        {
            int number = (int)Math.Sqrt(n);

            if (Math.Pow(number, 2) == n)
            {
                number++;
            }

            return number;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NumericalSequenceEnumerator(_minNumber, _maxNumber);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NumericalSequenceEnumerator(_minNumber, _maxNumber);
        }
    }
}
