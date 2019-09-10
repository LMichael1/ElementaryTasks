using NLog;
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

        private readonly int _startNumber;

        private readonly int _maxNumber;

        private int _position;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        public int Current
        {
            get
            {
                if (_position == _startNumber || _position > _maxNumber)
                {
                    _logger.Error("Position is out of range: {0}", _position);

                    throw new InvalidOperationException();
                }

                _logger.Info("Returning int position: {0}", _position);

                return _position;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                _logger.Info("Returning object position: {0}", Current);

                return Current;
            }
        }

        #endregion

        public NumericalSequenceEnumerator(int startNumber, int maxNumber)
        {
            _position = startNumber;
            _startNumber = startNumber;
            _maxNumber = maxNumber;

            _logger.Info("Enumerator created. Start number: {0}, Max number: {1}",
                startNumber, maxNumber);
        }

        public bool MoveNext()
        {
            if (_position < _maxNumber)
            {
                _position++;

                _logger.Info("Moving next. New position: {0}", _position);

                return true;
            }

            _logger.Warn("Moving next is not possible. Position: {0}",
                _position);

            return false;
        }

        public void Reset()
        {
            _position = _startNumber;

            _logger.Info("Position reseted to value {0}", _position);
        }

        public void Dispose()
        {
            //No resources to dispose
        }
    }
}
