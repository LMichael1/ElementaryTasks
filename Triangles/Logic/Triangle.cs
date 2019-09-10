using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSort
{
    public class Triangle : IComparable<Triangle>
    {
        #region Properties 

        public string Name { get; private set; }
        public double FirstSide { get; private set; }
        public double SecondSide { get; private set; }
        public double ThirdSide { get; private set; }
        public double Perimeter
        {
            get => FirstSide + SecondSide + ThirdSide;
        }
        private double SemiPerimeter
        {
            get => Perimeter / 2;
        }
        public double Area
        {
            get => Math.Sqrt(SemiPerimeter * (SemiPerimeter - FirstSide) *
                (SemiPerimeter - SecondSide) * (SemiPerimeter - ThirdSide));
        }

        #endregion

        public Triangle(string name, double firstSide, double secondSide, double thirdSide)
        {
            Name = name;
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public int CompareTo(Triangle other)
        {
            if (Area.CompareTo(other.Area) == 0)
            {
                return Name.CompareTo(other.Name);
            }

            return Area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            string result = string.Format("[Triangle {0}]: {1} cm", Name, Area);

            return result;
        }
    }
}
