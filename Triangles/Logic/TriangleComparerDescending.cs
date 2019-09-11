using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSort
{
    public class TriangleComparerDescending : IComparer<Triangle>
    {
        public int Compare(Triangle x, Triangle y)
        {
            return y.CompareTo(x);
        }
    }
}
