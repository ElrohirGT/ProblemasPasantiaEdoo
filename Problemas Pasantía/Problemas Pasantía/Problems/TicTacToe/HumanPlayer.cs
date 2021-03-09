using System;
using static ConsoleUtilitiesLite.ConsoleUtilitiesLite;

namespace Problemas_Pasantía.Problems.TicTacToe
{
    internal class HumanPlayer : IPlayer
    {
        public HumanPlayer(string name, TicTacToeCellValue sign)
        {
            Name = name;
            Sign = sign;
        }

        public string Name { get; }
        public TicTacToeCellValue Sign { get; }

        public void MakeMove(ITicTacToeBoard ticTacToeBoard)
        {
            while (true)
            {
                Console.Write($"{Name}: ");
                var response = Console.ReadLine().Trim();
                string[] possibleNumbers = response.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (possibleNumbers.Length != 2 ||
                    !int.TryParse(possibleNumbers[0], out int row) ||
                    !int.TryParse(possibleNumbers[1], out int cell))
                {
                    LogErrorMessage("Remember, the correct format is: row cell. Example: 1 3");
                    continue;
                }

                if (!ticTacToeBoard.TryMarkCell(row - 1, cell - 1, Sign))
                {
                    LogErrorMessage("Can't mark that cell! Please write a valid one.");
                    continue;
                }

                break;
            }
        }
    }
}
