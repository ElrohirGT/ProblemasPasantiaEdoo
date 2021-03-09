using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static ConsoleUtilitiesLite.ConsoleUtilitiesLite;

namespace Problemas_Pasantía.Problems.TicTacToe
{
    internal class TicTacToeBoard : ITicTacToeBoard
    {
        const int BOARD_SIZE = 3;

        int[][][] patterns = new int[][][]
        {
            new int[][]{
                new int[]{0,0},new int[]{0,1},new int[]{0,2},
            },
            new int[][]{
                new int[]{1,0},new int[]{1,1},new int[]{1,2}
            },
            new int[][]{
                new int[]{2,0 },new int[]{2,1},new int[]{2,2}
            },
            new int[][]{
                new int[]{0,0 },new int[]{1,1},new int[]{2,2}
            },
            new int[][]{
                new int[]{0,2 },new int[]{1,1},new int[]{2,0}
            }
        };

        ITicTacToeBoardCell[][] _board;
        private int _filledCellsCount = 0;

        public ReadOnlyCollection<ITicTacToeBoardCell[]> BoardState => Array.AsReadOnly(_board);

        public TicTacToeBoard()
        {
            _board = new ITicTacToeBoardCell[BOARD_SIZE][];

            for (int i = 0; i < BOARD_SIZE; i++)
                for (int j = 0; j < BOARD_SIZE; j++)
                    _board[i][j] = new TicTacToeBoardCell();
        }

        public bool IsThereAWinner { get; private set; } = false;
        public bool IsBoardFull => BOARD_SIZE * BOARD_SIZE == _filledCellsCount;

        public void ShowBoard()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    char cellValue = (char)_board[i][j].Value;
                    Console.Write($" {cellValue} ");
                    if ((j + 1) != BOARD_SIZE)
                        Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        public bool TryMarkCell(int row, int cell, TicTacToeCellValue sign)
        {
            if (row < 0 || cell < 0 || row >= BOARD_SIZE || cell >= BOARD_SIZE)
                return false;

            if (_board[row][cell].Value != TicTacToeCellValue.Default)
                return false;

            _board[row][cell].Value = sign;
            ++_filledCellsCount;

            IsThereAWinner = CheckIfSomeoneWon();

            return true;
        }

        private bool CheckIfSomeoneWon()
        {
            foreach (var pattern in patterns)
                if (CheckPattern(pattern))
                    return true;

            return false;
        }

        private bool CheckPattern(int[][] pattern)
        {
            TicTacToeCellValue signToCheck = _board[pattern[0][0]][pattern[0][1]].Value;

            if (signToCheck == TicTacToeCellValue.Default)
                return false;

            foreach (var cell in pattern)
            {
                if (signToCheck != _board[cell[0]][cell[1]].Value)
                    return false;
            }
            return true;
        }
    }
}