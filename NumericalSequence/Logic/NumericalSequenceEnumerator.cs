using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSequence
{
    public class NumericalSequenceEnumerator : IEnumerator<int>
    {
        #region Private fields

        private int _minNumber;

        private int _maxNumber;

        private int _position;

        #endregion

        #region Properties

        public object Current
        {
            get
            {
                return Current;
            }
        }

        int IEnumerator<int>.Current
        {
            get
            {
                if (_position == _minNumber || _position > _maxNumber)
                {
                    throw new InvalidOperationException();
                }
                return _position;
            }
        }

        #endregion

        public NumericalSequenceEnumerator(int minNumber, int maxNumber)
        {
            _position = minNumber - 1;
            _minNumber = minNumber - 1;
            _maxNumber = maxNumber;
        }

        public bool MoveNext()
        {
            if (_position < _maxNumber)
            {
                _position++;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = 0;
        }

        public void Dispose()
        {
            //No resources to dispose
        }
    }
}
