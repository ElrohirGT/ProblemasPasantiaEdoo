using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problemas_Pasantía.Problems.TicTacToe
{
    class TicTacToeBoardExamples
    {

        public void ShowDiagonalWins()
        {
            ITicTacToeBoard ticTacToeBoard = new TicTacToeBoard();

            ticTacToeBoard.TryMarkCell(0, 0, TicTacToeCellValue.Circle);
            ticTacToeBoard.TryMarkCell(1, 1, TicTacToeCellValue.Circle);
            ticTacToeBoard.TryMarkCell(2, 2, TicTacToeCellValue.Circle);

            ticTacToeBoard.TryMarkCell(0, 1, TicTacToeCellValue.Cross);
            ticTacToeBoard.TryMarkCell(0, 2, TicTacToeCellValue.Cross);

            ticTacToeBoard.ShowBoard();
        }

        internal void ShowInputExample()
        {
            ITicTacToeBoard ticTacToeBoard = new TicTacToeBoard();
            
            ticTacToeBoard.TryMarkCell(0, 0, TicTacToeCellValue.Cross);
            ticTacToeBoard.TryMarkCell(0, 1, TicTacToeCellValue.Cross);
            ticTacToeBoard.TryMarkCell(1, 1, TicTacToeCellValue.Circle);
            ticTacToeBoard.ShowBoard();

            Console.WriteLine("Let's say that you're oponent is cross and you want to block them. You'll need to type 1 3, because you want to block on the row 1 cell 3.");
            Console.WriteLine("Player2: 1 3");

            ticTacToeBoard.TryMarkCell(0, 2, TicTacToeCellValue.Circle);
            ticTacToeBoard.ShowBoard();
        }
    }
}
