using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace ChessBoard
{
    class Application
    {
        #region Constants

        private const string INVALID_NUMBER_OF_ARGS = "Invalid number of arguments. Please, enter numbers of rows and columns of board.";
        private const string INVALID_TYPE_OF_ARGS = "Arguments must be integers.";
        private const string INVALID_SIZE = "Minimum size of the board: 4x2.";
        private const string HELP = "Input number of rows and columns of the board. Minimum size of the board: 4x2.";

        private const int ARGS_LENGTH = 2;
        private const int MIN_NUMBER_OF_ROWS = 4;
        private const int MIN_NUMBER_OF_COLUMNS = 4;

        #endregion

        #region Fields

        private readonly IBoardValidator _validator;
        private readonly string[] _args;
        
        #endregion

        public Application(string[] args)
        {
            _validator = new BoardValidator(args, ARGS_LENGTH, MIN_NUMBER_OF_ROWS, MIN_NUMBER_OF_COLUMNS);
            _args = args;
        }

        public void Run()
        {
            switch (_validator.ValidateArgs())
            {
                case ArgsValidatorResult.Empty:
                    {
                        BoardUI.ShowMessage(HELP);
                        break;
                    }
                case ArgsValidatorResult.InvalidNumberOfArgs:
                    {
                        BoardUI.ShowMessage(INVALID_NUMBER_OF_ARGS);
                        break;
                    }
                case ArgsValidatorResult.InvalidTypeOfArgs:
                    {
                        BoardUI.ShowMessage(INVALID_TYPE_OF_ARGS);
                        break;
                    }
                case ArgsValidatorResult.InvalidValue:
                    {
                        BoardUI.ShowMessage(INVALID_SIZE);
                        break;
                    }
                case ArgsValidatorResult.Success:
                    {
                        Board checkersBoard = GetBoard();
                        RunWithBoard(checkersBoard);
                        break;
                    }
            }
        }

        private Board GetBoard()
        {
            int rows = Convert.ToInt32(_args[0]);
            int columns = Convert.ToInt32(_args[1]);

            return new Board(rows, columns);
        }

        private void RunWithBoard(Board checkersBoard)
        {
            BoardUI.DrawBoard(checkersBoard);
        }
    }
}
