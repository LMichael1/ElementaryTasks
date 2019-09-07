using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSort
{
    class TriangleValidator
    {
        public static bool IsTriangleExists(double firstSide, double secondSide, double thirdSide)
        {
            bool result = false;

            List<double> sides = new List<double> { firstSide, secondSide, thirdSide };
            sides.Sort();

            if (sides[0] + sides[1] > sides[2])
            {
                result = true;
            }

            return result;
        }
    }
}
