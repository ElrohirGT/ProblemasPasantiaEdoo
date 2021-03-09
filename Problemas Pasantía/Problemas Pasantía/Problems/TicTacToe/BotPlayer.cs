using System;
using System.Collections.ObjectModel;

namespace Problemas_Pasantía.Problems.TicTacToe
{
    class BotPlayer : IPlayer
    {
        #region Fields
        Random _randomNumberGenerator = new Random();
        int[][][] _patterns = new int[][][]
        {
            //Lineas horizontales
            new int[][]{
                new int[]{0,0},new int[]{0,1},new int[]{0,2},
            },
            new int[][]{
                new int[]{1,0},new int[]{1,1},new int[]{1,2}
            },
            new int[][]{
                new int[]{2,0 },new int[]{2,1},new int[]{2,2}
            },
            //Lineas diagonales
            new int[][]{
                new int[]{0,0 },new int[]{1,1},new int[]{2,2}
            },
            new int[][]{
                new int[]{0,2 },new int[]{1,1},new int[]{2,0}
            },
            //Lineas verticales
            new int[][]
            {
                new int[]{0,0}, new int[]{1,0}, new int[]{2,0}
            },
            new int[][]
            {
                new int[]{0,1}, new int[]{1,1}, new int[]{2,1}
            },
            new int[][]
            {
                new int[]{0,2}, new int[]{1,2}, new int[]{2,2}
            }
        };
        #endregion

        public BotPlayer(string name, TicTacToeCellValue sign)
        {
            Name = name;
            Sign = sign;
        }

        public string Name { get; }
        public TicTacToeCellValue Sign { get; }

        public void MakeMove(ITicTacToeBoard ticTacToeBoard)
        {
            if (MadeMoveToWin(ticTacToeBoard))
                return;
            if (MadeMoveToBlockOpponent(ticTacToeBoard))
                return;

            MakeRandomMove(ticTacToeBoard);
        }

        private bool MadeMoveToWin(ITicTacToeBoard ticTacToeBoard)
        {
            foreach (var pattern in _patterns)
            {
                if (CheckIfPatternIsAlmostComplete(pattern, ticTacToeBoard.BoardState, out int[] moveLocation, TicTacToeCellValue.Cross))
                {
                    MarkMove(ticTacToeBoard, moveLocation);
                    return true;
                }
            }
            return false;
        }
        private bool MadeMoveToBlockOpponent(ITicTacToeBoard ticTacToeBoard)
        {
            foreach (var pattern in _patterns)
            {
                if (CheckIfPatternIsAlmostComplete(pattern, ticTacToeBoard.BoardState, out int[] moveLocation, Sign))
                {
                    MarkMove(ticTacToeBoard, moveLocation);
                    return true;
                }
            }
            return false;
        }

        private void MarkMove(ITicTacToeBoard ticTacToeBoard, int[] moveLocation)
        {
            if (ticTacToeBoard.TryMarkCell(moveLocation[0], moveLocation[1], Sign))
                return;
            MakeRandomMove(ticTacToeBoard);
        }

        private bool CheckIfPatternIsAlmostComplete(int[][] pattern, ReadOnlyCollection<ITicTacToeBoardCell[]> boardState, out int[] moveLocation, TicTacToeCellValue enemySign)
        {
            int cellCount = 0;
            moveLocation = new int[2];

            foreach (var cell in pattern)
            {
                bool cellTakenByEnemy = boardState[cell[0]][cell[1]].Value == enemySign;
                bool emptyCell = boardState[cell[0]][cell[1]].Value == TicTacToeCellValue.Default;

                if (cellTakenByEnemy)
                    break;

                if (emptyCell)
                {
                    moveLocation = cell;
                    continue;
                }

                ++cellCount;
            }

            bool patternIsAlmostComplete = cellCount == 2;
            return patternIsAlmostComplete;
        }

        private void MakeRandomMove(ITicTacToeBoard ticTacToeBoard)
        {
            int row;
            int cell;
            do
            {
                row = _randomNumberGenerator.Next(0, 3);
                cell = _randomNumberGenerator.Next(0, 3);
            } while (!ticTacToeBoard.TryMarkCell(row, cell, Sign));
        }
    }
}
