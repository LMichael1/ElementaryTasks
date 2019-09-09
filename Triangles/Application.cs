using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace TriangleSort
{
    class Application
    {
        #region Constants

        private const double MIN_SIDE = 0.0;
        private const int ARGS_LENGTH = 4;

        #endregion

        #region Fields

        private ITriangleArgsValidator _validator;
        private List<Triangle> _triangles;
        private Logger _logger;

        #endregion

        public Application(string[] args)
        {
            _validator = new TriangleArgsValidator(args, ARGS_LENGTH, MIN_SIDE);
            _triangles = new List<Triangle>();
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Run()
        {
            if (_validator.IsArgsEmpty())
            {
                _logger.Info("Running without args.");
                RunWithoutArgs();
            }
            else
            {
                _logger.Info("Running with args.");
                RunWithArgs();
            }
        }

        private void RunWithArgs()
        {
            GetTriangle();

            if (ConsoleUI.WillContinue(StringConstants.CONTINUE))
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
            while (ConsoleUI.WillContinue(StringConstants.CONTINUE));

            if (_triangles.Count > 0)
            {
                RunProgram();
            }
        }

        private string[] GetArgs()
        {
            string userInput = ConsoleUI.GetValueFromInput(StringConstants.ENTER_TRIANGLE);
            string[] result = userInput.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            return result;
        }

        private void GetTriangle()
        {
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.InvalidNumberOfArgs:
                    _logger.Error("Invalid number of arguments.");
                    ConsoleUI.ShowMessage(StringConstants.INVALID_NUMBER_OF_ARGS);
                    break;

                case ArgsValidatorResult.InvalidTypeOfArgs:
                    _logger.Error("Invalid type of arguments.");
                    ConsoleUI.ShowMessage(StringConstants.INVALID_FORMAT);
                    break;

                case ArgsValidatorResult.InvalidValue:
                    _logger.Error("Invalid value of argument.");
                    ConsoleUI.ShowMessage(StringConstants.INVALID_ARGUMENT);
                    break;

                case ArgsValidatorResult.Success:
                    double firstSide = Convert.ToDouble(_validator.Args[1]);
                    double secondSide = Convert.ToDouble(_validator.Args[2]);
                    double thirdSide = Convert.ToDouble(_validator.Args[3]);

                    Triangle item = new Triangle(_validator.Args[0], firstSide, secondSide, thirdSide);

                    string loggerMessage = string.Format("Triangle created: {0}", item.ToString());
                    _logger.Info(loggerMessage);

                    _triangles.Add(item);
                    break;
            }
        }

        private void RunProgram()
        {
            _triangles.Sort(new SortTrianglesDescendingHelper());

            ConsoleUI.ShowMessage(StringConstants.LIST);

            ConsoleUI.Display(_triangles);
            _logger.Info("Success.");
        }
    }
}
