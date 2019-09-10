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

        #region Properties

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
                return Current;
            }
        } 

        #endregion

        public FibonacciEnumerator(int minNumber, int maxNumber)
        {
            _maxNumber = maxNumber;

            FindFirstFibonacci(minNumber);

            _startPosition = _position;
            _startX = _x;
            _startY = _y;
        }

        private void FindFirstFibonacci(int minNumber)
        {
            _x = 0;
            _y = 1;
            _position = 0;
            while (_x + _y < minNumber)
            {
                _position = _x + _y;
                _x = _y;
                _y = _position;
            }
        }

        public void Dispose()
        {
            //No resources to dispose
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
