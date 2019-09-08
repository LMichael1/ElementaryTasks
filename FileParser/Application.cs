using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;
using Validation;

namespace FileParser
{
    class Application
    {
        #region Constants

        private const string INVALID_NUMBER_OF_ARGS = "You must input 2 arguments to find number of entries or 3 arguments to replace substring. Try again.";
        private const string INVALID_FORMAT = "File doesn't exists. Try again.";
        private const string HELP = "You must input 2 arguments to find number of entries or 3 arguments to replace substring.";
        private const string FOUND = "{0} occurences found.";
        private const string REPLACED = "Substring was replaced.";

        private const int ARGS_LENGTH_FIND = 2;
        private const int ARGS_LENGTH_REPLACE = 3;

        #endregion

        #region Fields

        private readonly IParserArgsValidator _validator;
        private readonly string[] _args;

        #endregion

        public Application(string[] args)
        {
            _validator = new ParserArgsValidator(args, ARGS_LENGTH_FIND, ARGS_LENGTH_REPLACE);
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

                case ArgsValidatorResult.InvalidValue:
                    ConsoleUI.ShowMessage(INVALID_FORMAT);
                    break;

                case ArgsValidatorResult.Success:
                    if (_args.Length == 2)
                    {
                        RunSearch();
                    }
                    else
                    {
                        RunReplace();
                    }
                    break;
            }
        }

        private void RunSearch()
        {
            FileParser parser = new FileParser(_args[0]);
            int result = parser.GetNumberOfSubstringEntries(_args[1]);

            string message = string.Format(FOUND, result);

            ConsoleUI.ShowMessage(message);
        }

        private void RunReplace()
        {
            FileParser parser = new FileParser(_args[0]);
            parser.ReplaceAllSubstringEntries(_args[1], _args[2]);

            ConsoleUI.ShowMessage(REPLACED);
        }
    }
}
