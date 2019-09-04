﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles
{
    class SortTrianglesDescendingHelper : IComparer<Triangle>
    {
        public int Compare(Triangle x, Triangle y)
        {
            if (x.Area < y.Area)
            {
                return -1;
            }
            if (x.Area > y.Area)
            {
                return 1;
            }
            return 0;
        }
    }
}
