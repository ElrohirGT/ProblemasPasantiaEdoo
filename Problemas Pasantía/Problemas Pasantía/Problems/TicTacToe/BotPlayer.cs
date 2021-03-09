using System;

namespace Problemas_Pasantía.Problems.TicTacToe
{
    class BotPlayer : IPlayer
    {
        public BotPlayer(string name, TicTacToeCellValue sign)
        {
            Name = name;
            Sign = sign;
        }

        public string Name { get; }
        public TicTacToeCellValue Sign { get; }

        public void MakeMove(ITicTacToeBoard ticTacToeBoard)
        {
            throw new NotImplementedException();
        }
    }
}
