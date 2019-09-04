using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace Triangles
{
    class Application
    {
        #region Constants

        private const string ENTER_TRIANGLE = "Enter the name and sides of the triangle.";
        private const string INVALID_FORMAT = "Arguments must be numbers. Try again.";
        private const string INVALID_ARGUMENT = "Triangle doesn's exist. Try again.";
        private const string INVALID_NUMBER_OF_ARGS = "You must input 4 arguments separated by commas.";
        private const string CONTINUE = "Do you want to add more triangles? (Y/N)";
        private const string LIST = "=========== Triangles list ===========";

        private const double MIN_SIDE = 0.0;

        private const int ARGS_LENGTH = 4;

        #endregion

        private ITriangleValidator _validator;
        private List<Triangle> _triangles;

        public Application(string[] args)
        {
            _validator = new TriangleArgsValidator(args, ARGS_LENGTH, MIN_SIDE);
            _triangles = new List<Triangle>();
        }

        public void Run()
        {
            if (_validator.IsArgsEmpty())
            {
                RunWithoutArgs();
            }
            else
            {
                RunWithArgs();
            }
        }

        private void RunWithArgs()
        {
            GetTriangle();

            if (ConsoleUI.WillContinue(CONTINUE))
            {
                RunWithoutArgs();
            }
        }

        private void RunWithoutArgs()
        {
            do
            {
                _validator.Args = GetArgs();

                GetTriangle();
            }
            while (ConsoleUI.WillContinue(CONTINUE));

            if (_triangles.Count > 0)
            {
                RunProgram();
            }
        }

        private string[] GetArgs()
        {
            string userInput = ConsoleUI.GetValueFromInput(ENTER_TRIANGLE);
            string[] result = userInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return result;
        }

        private void GetTriangle()
        {
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.InvalidNumberOfArgs:
                    {
                        ConsoleUI.ShowMessage(INVALID_NUMBER_OF_ARGS);
                        break;
                    }
                case ArgsValidatorResult.InvalidTypeOfArgs:
                    {
                        ConsoleUI.ShowMessage(INVALID_FORMAT);
                        break;
                    }
                case ArgsValidatorResult.InvalidValue:
                    {
                        ConsoleUI.ShowMessage(INVALID_ARGUMENT);
                        break;
                    }
                case ArgsValidatorResult.Success:
                    {
                        double firstSide = Convert.ToDouble(_validator.Args[1]);
                        double secondSide = Convert.ToDouble(_validator.Args[2]);
                        double thirdSide = Convert.ToDouble(_validator.Args[3]);

                        Triangle item = new Triangle(_validator.Args[0], firstSide, secondSide, thirdSide);
                        _triangles.Add(item);
                        break;
                    }
            }
        }

        private void RunProgram()
        {
            _triangles.Sort(new SortTrianglesDescendingHelper());

            ConsoleUI.ShowMessage(LIST);

            ConsoleUI.Display(_triangles);
        }
    }
}
