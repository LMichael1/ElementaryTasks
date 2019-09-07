using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace NumericIntoWords
{
    class Application
    {
        #region Constants

        private const string INVALID_NUMBER_OF_ARGS = "You must input 1 argument.";
        private const string INVALID_FORMAT = "Argument must be an integer. Try again.";
        private const string HELP = "Enter the number to convert it into words.";

        private const int ARGS_LENGTH = 1;

        #endregion

        #region Fields

        private readonly INumericArgsValidator _validator;
        private readonly string[] _args;

        #endregion

        public Application(string[] args)
        {
            _validator = new NumericArgsValidator(args, ARGS_LENGTH);
            _args = args;
        }

        public void Run()
        {
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.Empty:
                    ConsoleUI.ShowMessage(HELP);
                    break;
                case ArgsValidatorResult.InvalidNumberOfArgs:
                    ConsoleUI.ShowMessage(INVALID_NUMBER_OF_ARGS);
                    break;
                case ArgsValidatorResult.InvalidTypeOfArgs:
                    ConsoleUI.ShowMessage(INVALID_FORMAT);
                    break;
                case ArgsValidatorResult.Success:
                    RunConverter(Convert.ToInt32(_args[0]));
                    break;
            }
        }

        private void RunConverter(int number)
        {
            NumberConverter converter = new NumberConverter(new EnglishNumbers());
            string result = converter.Convert(number);

            ConsoleUI.ShowMessage(result);
        }
    }
}
