using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSort
{
    public class Triangle : IComparable<Triangle>
    {
        #region Fields

        private static Logger _logger = LogManager.GetCurrentClassLogger(); 

        #endregion

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

        public Triangle(string name, double firstSide, 
            double secondSide, double thirdSide)
        {
            Name = name;
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            _logger.Info("Triangle created: {0}, {1}, {2}, {3}", 
                name, firstSide, secondSide, thirdSide);
        }

        public int CompareTo(Triangle other)
        {
            if (other == null)
            {
                _logger.Error("Comparsion with not initialized triangle.");
                throw new ArgumentNullException(StringConstants.ARGUMENT_NULL);
            }

            _logger.Info("Comparing triangle {0} with triangle {1}...",
                Name, other.Name);

            int result = Area.CompareTo(other.Area);

            if (result == 0)
            {
                result = Name.CompareTo(other.Name);

                _logger.Info("The areas are equal. Comparing by name...");
                _logger.Info("Comparsion result: {0}", result);

                return result;
            }

            _logger.Info("Comparsion result: {0}", result);

            return result;
        }

        public override string ToString()
        {
            return string.Format("[Triangle {0}]: {1} cm", Name, Area);
        }
    }
}
