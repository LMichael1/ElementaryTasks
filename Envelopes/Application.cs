using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

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

        private IEnvelopeValidator _validator;

        #endregion

        public Application()
        {
            _validator = new EnvelopeValidator(ARGS_LENGTH, MIN_LENGTH, MIN_WIDTH);
        }

        public void Run(string[] args)
        {
            if (_validator.IsArgsEmpty(args))
            {
                RunWithoutArgs();
            }
            else
            {
                RunWithArgs(args);
            }
        }

        public void RunWithArgs(string[] args)
        {
            if (_validator.IsNumberOfArgsValid(args))
            {
                Envelope firstEnvelope = GetEnvelope(args[0], args[1]);
                Envelope secondEnvelope = GetEnvelope(args[2], args[3]);

                if (firstEnvelope != null && secondEnvelope != null)
                {
                    RunWithEnvelopes(firstEnvelope, secondEnvelope);
                }
            }
            else
            {
                UI.ShowMessage(INVALID_NUMBER_OF_ARGS);
            }
        }

        public void RunWithoutArgs()
        {
            do
            {
                UI.ShowMessage(FIRST_ENVELOPE);
                Envelope firstEnvelope = GetEnvelope();

                UI.ShowMessage(SECOND_ENVELOPE);
                Envelope secondEnvelope = GetEnvelope();

                if (firstEnvelope != null && secondEnvelope != null)
                {
                    RunWithEnvelopes(firstEnvelope, secondEnvelope);
                }

                UI.ShowMessage(CONTINUE);
            }
            while (UI.WillContinue());
        }

        private void RunWithEnvelopes(Envelope first, Envelope second)
        {
            CompareResult result = Envelope.CompareEnvelopes(first, second);

            switch (result)
            {
                case CompareResult.FirstCanContainSecond:
                    {
                        UI.ShowMessage(FIRST_CAN_CONTAIN_SECOND);
                        break;
                    }
                case CompareResult.SecondCanContainFirst:
                    {
                        UI.ShowMessage(SECOND_CAN_CONTAIN_FIRST);
                        break;
                    }
                case CompareResult.NotFitted:
                    {
                        UI.ShowMessage(CAN_NOT_CONTAIN);
                        break;
                    }
            }
        }

        private Envelope GetEnvelope()
        {
            Envelope result = null;

            UI.ShowMessage(ENTER_LENGTH);
            string strLength = UI.GetValueFromInput();

            UI.ShowMessage(ENTER_WIDTH);
            string strWidth = UI.GetValueFromInput();

            if (!_validator.IsArgsNumbers(strLength, strWidth))
            {
                UI.ShowMessage(INVALID_FORMAT);

                return result;
            }

            int length = Convert.ToInt32(strLength);
            int width = Convert.ToInt32(strWidth);

            if (!_validator.IsSizesValid(length, width))
            {
                UI.ShowMessage(INVALID_ARGUMENT);

                return result;
            }

            return new Envelope(length, width);
        }

        private Envelope GetEnvelope(string strLength, string strWidth)
        {
            Envelope result = null;

            if (!_validator.IsArgsNumbers(strLength, strWidth))
            {
                UI.ShowMessage(INVALID_FORMAT);

                return result;
            }

            int length = Convert.ToInt32(strLength);
            int width = Convert.ToInt32(strWidth);

            if (!_validator.IsSizesValid(length, width))
            {
                UI.ShowMessage(INVALID_ARGUMENT);

                return result;
            }

            return new Envelope(length, width);
        }
    }
}
