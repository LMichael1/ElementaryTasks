using NLog;
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

        private int _startNumber;
        private int _maxNumber;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        public NumericalSequence(int square)
        {
            _startNumber = 1;
            _maxNumber = GetMaxNumber(square);

            _logger.Info("Sequence created. Square: {0}, Max number: {1}", 
                square, _maxNumber);
        }

        public NumericalSequence(int startNumber, int maxSquare)
        {
            _startNumber = startNumber;
            _maxNumber = GetMaxNumber(maxSquare);

            _logger.Info("Sequence created. Start number: {0}, Square: {2}, Max number: {2}",
                startNumber, maxSquare, _maxNumber);
        }

        private int GetMaxNumber(int square)
        {
            int number = (int)Math.Sqrt(square);

            if (Math.Pow(number, 2) == square)
            {
                number--;
            }

            return number;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NumericalSequenceEnumerator(_startNumber - 1, _maxNumber);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NumericalSequenceEnumerator(_startNumber - 1, _maxNumber);
        }
    }
}
