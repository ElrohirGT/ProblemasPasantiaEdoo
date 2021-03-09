using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Problemas_Pasantía.Problems.TicTacToe
{
    internal interface ITicTacToeBoard
    {
        public ReadOnlyCollection<ITicTacToeBoardCell[]> BoardState { get; }
        bool IsBoardFull { get; }
        bool IsThereAWinner { get; }

        void ShowBoard();
        bool TryMarkCell(int row, int cell, TicTacToeCellValue sign);
    }
}