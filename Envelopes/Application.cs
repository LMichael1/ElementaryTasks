using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace Envelopes
{
    class Application
    {
        #region Constants

        private const string ENTER_LENGTH = "Enter the length of the envelope.";
        private const string ENTER_WIDTH = "Enter the width of the envelope.";
        private const string INVALID_FORMAT = "Arguments must be numbers. Try again.";
        private const string INVALID_ARGUMENT = "Arguments must be greater than zero. Try again.";
        private const string INVALID_NUMBER_OF_ARGS = "You must input 4 arguments.";
        private const string CONTINUE = "Do you want to continue? (Y/N)";
        private const string FIRST_ENVELOPE = "First envelope:";
        private const string SECOND_ENVELOPE = "Second envelope:";
        private const string FIRST_CAN_CONTAIN_SECOND = "First envelope can contain second.";
        private const string SECOND_CAN_CONTAIN_FIRST = "Second envelope can contain first.";
        private const string CAN_NOT_CONTAIN = "Envelope can't contain each other.";

        private const double MIN_LENGTH = 0.0;
        private const double MIN_WIDTH = 0.0;

        private const int ARGS_LENGTH = 4;

        #endregion

        #region Fields

        private readonly IEnvelopeArgsValidator _validator;
        private readonly string[] _args;

        #endregion

        public Application(string[] args)
        {
            _validator = new EnvelopeArgsValidator(args, ARGS_LENGTH, MIN_LENGTH, MIN_WIDTH);
            _args = args;
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
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.InvalidNumberOfArgs:
                    ConsoleUI.ShowMessage(INVALID_NUMBER_OF_ARGS);
                    break;

                case ArgsValidatorResult.InvalidTypeOfArgs:
                    ConsoleUI.ShowMessage(INVALID_FORMAT);
                    break;
                case ArgsValidatorResult.InvalidValue:
                    ConsoleUI.ShowMessage(INVALID_ARGUMENT);
                    break;
                case ArgsValidatorResult.Success:
                    Envelope firstEnvelope = GetEnvelope(_args[0], _args[1]);
                    Envelope secondEnvelope = GetEnvelope(_args[2], _args[3]);
                    RunWithEnvelopes(firstEnvelope, secondEnvelope);
                    break;
            }
        }

        public void RunWithoutArgs()
        {
            do
            {
                ConsoleUI.ShowMessage(FIRST_ENVELOPE);
                Envelope firstEnvelope = GetEnvelope();

                if (firstEnvelope == null)
                {
                    break;
                }

                ConsoleUI.ShowMessage(SECOND_ENVELOPE);
                Envelope secondEnvelope = GetEnvelope();

                if (secondEnvelope == null)
                {
                    break;
                }

                RunWithEnvelopes(firstEnvelope, secondEnvelope);
            }
            while (ConsoleUI.WillContinue(CONTINUE));
        }

        private void RunWithEnvelopes(Envelope first, Envelope second)
        {
            CompareResult result = Envelope.CompareEnvelopes(first, second);

            switch (result)
            {
                case CompareResult.FirstCanContainSecond:
                    {
                        ConsoleUI.ShowMessage(FIRST_CAN_CONTAIN_SECOND);
                        break;
                    }
                case CompareResult.SecondCanContainFirst:
                    {
                        ConsoleUI.ShowMessage(SECOND_CAN_CONTAIN_FIRST);
                        break;
                    }
                case CompareResult.NotFitted:
                    {
                        ConsoleUI.ShowMessage(CAN_NOT_CONTAIN);
                        break;
                    }
            }
        }

        private Envelope GetEnvelope()
        {
            Envelope result = null;

            string strLength = ConsoleUI.GetValueFromInput(ENTER_LENGTH);

            string strWidth = ConsoleUI.GetValueFromInput(ENTER_WIDTH);

            switch (_validator.ValidateEnvelope(strLength, strWidth))
            {
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
                        double envelopeLength = Convert.ToDouble(strLength);
                        double envelopeWidth = Convert.ToDouble(strWidth);
                        result = new Envelope(envelopeLength, envelopeWidth);
                        break;
                    }
            }

            return result;
        }

        private Envelope GetEnvelope(string strLength, string strWidth)
        {
            int length = Convert.ToInt32(strLength);
            int width = Convert.ToInt32(strWidth);

            return new Envelope(length, width);
        }
    }
}
