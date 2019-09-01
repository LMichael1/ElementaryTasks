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
        #region Properties

        public int Count { get; }

        #endregion

        public int this[int index]
        {
            get
            {
                if (index < Count)
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
            Count = GetMaxNumber(n);
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
            return new NumericalSequenceEnumerator(Count);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NumericalSequenceEnumerator(Count);
        }

        public override string ToString()
        {
            return string.Join(", ", this.ToList());
        }
    }
}
