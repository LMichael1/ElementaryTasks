using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace Fibonacci
{
    class Application
    {
        private const string INVALID_NUMBER_OF_ARGS = "You must input 2 arguments. Try again.";
        private const string INVALID_FORMAT = "Arguments must be numbers. Try again.";
        private const string INVALID_SIZE = "Second argument must be greater than first. Try again.";
        private const string HELP = "Enter the range for the Fibonacci sequence.";

        private const int ARGS_LENGTH = 2;

        private ISequenceValidator _validator;

        public Application()
        {
            _validator = new SequenceValidator(ARGS_LENGTH);
        }

        public void Run(string[] args)
        {
            if (_validator.IsArgsEmpty(args))
            {
                UI.ShowMessage(HELP);
            }
            else
            {
                FibonacciSequence sequence = GetSequence(args);
                if (sequence != null)
                {
                    RunWithSequence(sequence);
                }
            }
        }

        private void RunWithSequence(FibonacciSequence sequence)
        {
            UI.ShowMessage(sequence.ToString());
        }

        public FibonacciSequence GetSequence(string[] args)
        {
            FibonacciSequence sequence = null;

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

            int minNumber = Convert.ToInt32(args[0]);
            int maxNumber = Convert.ToInt32(args[1]);

            if (!_validator.IsValuesValid(minNumber, maxNumber))
            {
                UI.ShowMessage(INVALID_SIZE);

                return sequence;
            }

            sequence = new FibonacciSequence(minNumber, maxNumber);

            return sequence;
        }
    }
}
