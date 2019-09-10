using NLog;
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
        #region Constants

        private const int ARGS_LENGTH = 1;
        private const int MIN_VALUE = 2;

        #endregion

        #region Fields

        private readonly ISequenceArgsValidator _validator;
        private readonly string[] _args;
        private Logger _logger;

        #endregion

        public Application(string[] args)
        {
            _validator = new SequenceArgsValidator(args, ARGS_LENGTH, MIN_VALUE);
            _args = args;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Run()
        {
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.Empty:
                    _logger.Error("Argbments are empty.");
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
        }

        private void RunWithSequence(NumericalSequence sequence)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var i in sequence)
            {
                sb.AppendFormat("{0}, ", i);
            }
            sb.Length -= 2;

            ConsoleUI.ShowMessage(sb.ToString());
            _logger.Info("Success");
        }

        private NumericalSequence GetSequence()
        {
            int number = Convert.ToInt32(_args[0]);

            return new NumericalSequence(number);
        }

    }
}
