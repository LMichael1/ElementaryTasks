using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSequence
{
    class NumericalSequenceEnumerator : IEnumerator<int>
    {
        #region Private fields

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
                if (_position == 0 || _position > _maxNumber)
                {
                    throw new InvalidOperationException();
                }
                return _position;
            }
        }

        #endregion

        public NumericalSequenceEnumerator(int maxNumber)
        {
            _position = 0;
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
