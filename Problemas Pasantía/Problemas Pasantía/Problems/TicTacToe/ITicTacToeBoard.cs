namespace Problemas_Pasantía.Problems.TicTacToe
{
    internal interface ITicTacToeBoard
    {
        bool IsBoardFull { get; }
        bool IsThereAWinner { get; }

        void ShowBoard();
        bool TryMarkCell(int row, int cell, TicTacToeCellValue sign);
    }
}