using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace ChessBoard
{
    class BoardUI : UI
    {
        public static void DrawBoard(IBoard board)
        {
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < board.NumberOfRows; i++)
            {
                for (int j = 0; j < board.NumberOfColumns; j++)
                {
                    Console.BackgroundColor = GetConsoleBackgroundColor(board.GetCell(i, j));

                    if (board.GetCell(i, j).IsOccupied)
                    {
                        DrawPiece(board.GetPiece(i, j));
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }

            ResetConsoleColors();
        }

        private static ConsoleColor GetConsoleBackgroundColor(Cell boardCell)
        {
            ConsoleColor result;

            if (boardCell.Color == CellColor.Black)
            {
                result = ConsoleColor.DarkGray;
            }
            else
            {
                result = ConsoleColor.Yellow;
            }

            return result;
        }

        private static ConsoleColor GetConsoleForegroundColor(Piece boardPiece)
        {
            ConsoleColor result;

            if (boardPiece.Color == PieceColor.Black)
            {
                result = ConsoleColor.Black;
            }
            else
            {
                result = ConsoleColor.White;
            }

            return result;
        }

        private static void DrawPiece(Piece pieceToDraw)
        {
            Console.ForegroundColor = GetConsoleForegroundColor(pieceToDraw);

            if (pieceToDraw is King)
            {
                Console.Write(" ◦ ");
            }
            else
            {
                Console.Write(" • ");
            }
        }
    }
}
