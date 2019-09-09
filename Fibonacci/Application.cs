using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace Fibonacci
{
    class Application
    {
        #region Constants

        private const string INVALID_NUMBER_OF_ARGS = "You must input 2 arguments. Try again.";
        private const string INVALID_FORMAT = "Arguments must be numbers. Try again.";
        private const string INVALID_SIZE = "Second argument must be greater than first. Try again.";
        private const string HELP = "Enter the range for the Fibonacci sequence.";
        private const string NO_FIBONACCI = "No fibonacci numbers in range.";

        private const int ARGS_LENGTH = 2;

        #endregion

        #region Fields

        private readonly ISequenceArgsVaildator _validator;
        private readonly string[] _args;

        #endregion

        public Application(string[] args)
        {
            _validator = new FibonacciArgsValidator(args, ARGS_LENGTH);
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

                case ArgsValidatorResult.InvalidValue:
                    ConsoleUI.ShowMessage(INVALID_SIZE);
                    break;

                case ArgsValidatorResult.Success:
                    FibonacciSequence sequence = GetSequence();
                    RunWithSequence(sequence);
                    break;
            }
        }

        private void RunWithSequence(FibonacciSequence sequence)
        {
            var stringBuilder = new StringBuilder();

            foreach (var i in sequence)
            {
                stringBuilder.AppendFormat("{0}, ", i);
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Length -= 2;
                ConsoleUI.ShowMessage(stringBuilder.ToString());
            }
            else
            {
                ConsoleUI.ShowMessage(NO_FIBONACCI);
            }
        }

        private FibonacciSequence GetSequence()
        {
            int minNumber = Convert.ToInt32(_args[0]);
            int maxNumber = Convert.ToInt32(_args[1]);

            return new FibonacciSequence(minNumber, maxNumber);
        }
    }
}
