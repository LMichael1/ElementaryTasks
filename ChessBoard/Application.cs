using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private IBoardValidator _validator;
        
        #endregion

        public Application()
        {
            _validator = new BoardValidator(ARGS_LENGTH, MIN_NUMBER_OF_ROWS, MIN_NUMBER_OF_COLUMNS);
        }

        public void Run(string[] args)
        {
            if (args.Length == 0)
            {
                BoardUI.ShowMessage(HELP);
            }
            else
            {
                Board checkersBoard = GetBoard(args);
                if (checkersBoard != null)
                {
                    RunWithBoard(checkersBoard);
                }
            }
        }

        private Board GetBoard(string[] args)
        {
            Board result = null;

            if (!_validator.IsNumberOfArgsValid(args))
            {
                BoardUI.ShowMessage(INVALID_NUMBER_OF_ARGS);

                return result;
            }

            if (!_validator.IsArgsNumbers(args))
            {
                BoardUI.ShowMessage(INVALID_TYPE_OF_ARGS);

                return result;
            }

            int rows = Convert.ToInt32(args[0]);
            int columns = Convert.ToInt32(args[1]);

            if (!_validator.IsSizesValid(rows, columns))
            {
                BoardUI.ShowMessage(INVALID_SIZE);

                return result;
            }

            result = new Board(rows, columns);

            return result;
        }

        private void RunWithBoard(Board checkersBoard)
        {
            BoardUI.DrawBoard(checkersBoard);
        }
    }
}
