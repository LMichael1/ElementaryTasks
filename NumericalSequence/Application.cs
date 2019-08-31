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
        private const string INVALID_NUMBER_OF_ARGS = "You must input 1 argument.";
        private const string INVALID_FORMAT = "Argument must be a natural number. Try again.";
        private const string HELP = "Enter a number to get a sequence of natural numbers whose square is less than a given number.";

        private const int ARGS_LENGTH = 1;
        private const int MIN_VALUE = 2;

        private ISequenceValidator _validator;

        public Application()
        {
            _validator = new SequenceValidator(ARGS_LENGTH, MIN_VALUE);
        }

        public void Run(string[] args)
        {
            if (_validator.IsArgsEmpty(args))
            {
                UI.ShowMessage(HELP);
            }
            else
            {
                NumericalSequence sequence = GetSequence(args);
                if (sequence != null)
                {
                    RunWithSequence(sequence);
                }
            }
        }

        private void RunWithSequence(NumericalSequence sequence)
        {
            UI.ShowMessage(sequence.ToString());
        }

        public NumericalSequence GetSequence(string[] args)
        {
            NumericalSequence sequence = null;

            if (!_validator.IsNumberOfArgsValid(args))
            {
                UI.ShowMessage(INVALID_NUMBER_OF_ARGS);

                return sequence;
            }

            if (!_validator.IsArgsNumbers(args))
            {
                UI.ShowMessage(INVALID_FORMAT);

                return sequence;
            }

            int number = Convert.ToInt32(args[0]);

            if (!_validator.IsValueValid(number))
            {
                UI.ShowMessage(INVALID_FORMAT);

                return sequence;
            }

            sequence = new NumericalSequence(number);

            return sequence;
        }


    }
}
