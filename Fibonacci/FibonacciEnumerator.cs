using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class FibonacciEnumerator : IEnumerator<int>
    {
        #region Private fields

        private int _maxNumber;

        private int _position;

        private int _x;

        private int _y;

        private readonly int _startPosition;

        private readonly int _startX;

        private readonly int _startY;

        #endregion

        public FibonacciEnumerator(int maxNumber, int x, int y, int z)
        {
            _maxNumber = maxNumber;

            _startPosition = z;
            _startX = x;
            _startY = y;

            _position = z;
            _x = x;
            _y = y;
        }

        public int Current
        {
            get
            {
                if (_position == _startPosition || _position > _maxNumber)
                {
                    throw new InvalidOperationException();
                }
                return _position;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return Current;
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
            }
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (_x + _y <= _maxNumber)
            {
                _position = _x + _y;
                _x = _y;
                _y = _position;

                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = _startPosition;
            _x = _startX;
            _y = _startY;
        }
    }
}
