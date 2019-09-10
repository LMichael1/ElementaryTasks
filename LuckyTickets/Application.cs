using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace LuckyTickets
{
    class Application
    {
        #region Constants

        private const int ARGS_LENGTH = 2;

        #endregion

        #region Fields

        private ITicketsArgsValidator _validator;
        private string[] _args; 

        #endregion

        public Application(string[] args)
        {
            _validator = new TicketsArgsValidator(args, ARGS_LENGTH);
            _args = args;
        }

        public void Run()
        {
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.Empty:
                    ConsoleUI.ShowMessage(StringConstants.HELP);
                    break;

                case ArgsValidatorResult.InvalidNumberOfArgs:
                    ConsoleUI.ShowMessage(StringConstants.INVALID_NUMBER_OF_ARGS);
                    break;

                case ArgsValidatorResult.InvalidTypeOfArgs:
                    ConsoleUI.ShowMessage(StringConstants.INVALID_ALGORITHM);
                    break;

                case ArgsValidatorResult.InvalidValue:
                    ConsoleUI.ShowMessage(StringConstants.INVALID_FORMAT);
                    break;

                case ArgsValidatorResult.Success:
                    RunAlgorithm(GetTicketsList());
                    break;
            }
        }

        private void RunAlgorithm(List<Ticket> tickets)
        {
            int result = 0;

            switch (_args[1].ToUpper())
            {
                case StringConstants.MOSCOW:
                    MoscowAlgorithm algorithmMoscow = new MoscowAlgorithm(tickets);
                    result = algorithmMoscow.GetNumberOfLuckyTickets();
                    break;
                case StringConstants.PETER:
                    PeterAlgorithm algorithmPeter = new PeterAlgorithm(tickets);
                    result = algorithmPeter.GetNumberOfLuckyTickets();
                    break;
            }

            ConsoleUI.ShowMessage(string.Format(StringConstants.RESULT, result));
        }

        private List<Ticket> GetTicketsList()
        {
            StreamReader reader = new StreamReader(_args[0]);
            TicketFileParser parser = new TicketFileParser(reader);

            return parser.GetTickets();
        }
    }
}
