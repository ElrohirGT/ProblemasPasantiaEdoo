namespace Problemas_Pasantía.Problems.TicTacToe
{
    internal class TicTacToeBoardCell : ITicTacToeBoardCell
    {
        public TicTacToeBoardCell() { }

        public TicTacToeCellValue Value { get; set; } = TicTacToeCellValue.Default;
    }
}