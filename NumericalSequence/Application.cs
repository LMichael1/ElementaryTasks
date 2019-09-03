using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace NumericalSequence
{
    class Application
    {
        #region Constants

        private const string INVALID_NUMBER_OF_ARGS = "You must input 1 argument.";
        private const string INVALID_FORMAT = "Argument must be a natural number. Try again.";
        private const string HELP = "Enter the number to get a sequence of natural numbers whose square is less than a given number."; 

        private const int ARGS_LENGTH = 1;
        private const int MIN_VALUE = 2;

        #endregion

        #region Fields

        private readonly ISequenceValidator _validator;
        private readonly string[] _args; 

        #endregion

        public Application(string[] args)
        {
            _validator = new SequenceValidator(args, ARGS_LENGTH, MIN_VALUE);
            _args = args;
        }

        public void Run()
        {
            switch(_validator.ValidateArgs())
            {
                case ArgsValidatorResult.Empty:
                    {
                        ConsoleUI.ShowMessage(HELP);
                        break;
                    }
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
                        ConsoleUI.ShowMessage(INVALID_FORMAT);
                        break;
                    }
                case ArgsValidatorResult.Success:
                    {
                        NumericalSequence sequence = GetSequence();
                        RunWithSequence(sequence);
                        break;
                    }
            }
        }

        private void RunWithSequence(NumericalSequence sequence)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in sequence)
            {
                sb.Append(i);
                sb.Append(", ");
            }
            sb.Length -= 2;

            ConsoleUI.ShowMessage(sb.ToString());
        }

        private NumericalSequence GetSequence()
        {
            int number = Convert.ToInt32(_args[0]);

            return new NumericalSequence(number);
        }

    }
}
