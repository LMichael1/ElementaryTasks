﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles
{
    class Triangle : IComparable<Triangle>
    {
        #region Properties 

        public string Name { get; }
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }
        public double SemiPerimeter
        {
            get => (FirstSide + SecondSide + ThirdSide) / 2;
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
            return Area.CompareTo(other.Area);
        }
    }
}
