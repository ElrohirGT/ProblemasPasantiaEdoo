namespace Problemas_Pasantía.Problems.TicTacToe
{
    internal interface IPlayer
    {
        string Name { get; }
        TicTacToeCellValue Sign { get; }

        void MakeMove(ITicTacToeBoard ticTacToeBoard);
    }
}