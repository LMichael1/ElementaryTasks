using NLog;
using NumericalSequence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace NumericalSequence
{
    public class Application
    {
        #region Fields

        private readonly ISequenceArgsValidator _validator;
        private readonly string[] _args;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        public Application(string[] args)
        {
            _validator = new SequenceArgsValidator(args, NumericConstants.ARGS_LENGTH,
                NumericConstants.ARGS_LENGTH_FOR_RANGE, NumericConstants.MIN_VALUE);
            _args = args;
        }

        public void Run()
        {
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.Empty:
                    _logger.Error("Arguments are empty.");
                    ConsoleUI.ShowMessage(StringConstants.HELP);
                    break;

                case ArgsValidatorResult.InvalidNumberOfArgs:
                    _logger.Error("Invalid number of arguments.");
                    ConsoleUI.ShowMessage(StringConstants.INVALID_NUMBER_OF_ARGS);
                    break;

                case ArgsValidatorResult.InvalidTypeOfArgs:
                    _logger.Error("Invalid type of arguments.");
                    ConsoleUI.ShowMessage(StringConstants.INVALID_FORMAT);
                    break;

                case ArgsValidatorResult.InvalidValue:
                    _logger.Error("Invalid values of arguments.");
                    ConsoleUI.ShowMessage(StringConstants.INVALID_FORMAT);
                    break;

                case ArgsValidatorResult.Success:
                    NumericalSequence sequence = GetSequence();
                    RunWithSequence(sequence);
                    break;
            }

            ConsoleUI.PressKeyToContinue(StringConstants.PRESS_KEY_TO_CONTINUE);
        }

        private void RunWithSequence(NumericalSequence sequence)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var i in sequence)
            {
                stringBuilder.AppendFormat("{0}, ", i);
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Length -= 2;

                ConsoleUI.ShowMessage(StringConstants.SEQUENCE);
                ConsoleUI.ShowMessage(stringBuilder.ToString());
                _logger.Info("Success");
            }
            else
            {
                ConsoleUI.ShowMessage(StringConstants.NO_NUMBERS_IN_RANGE);
                _logger.Warn("No numbers in range.");
            }
        }

        private NumericalSequence GetSequence()
        {
            int square;

            if (_args.Length == 1)
            {
                square = Convert.ToInt32(_args[0]);

                return new NumericalSequence(square);
            }

            int startNumber = Convert.ToInt32(_args[0]);
            square = Convert.ToInt32(_args[1]);

            return new NumericalSequence(startNumber, square);
        }

    }
}
