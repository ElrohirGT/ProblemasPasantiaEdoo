using Problemas_Pasantía.Problems.TicTacToe;
using System;
using static ConsoleUtilitiesLite.ConsoleUtilitiesLite;

//Realice un juego de tres en línea donde hayan dos jugadores.

namespace Problemas_Pasantía
{
    internal class Problem4 : IProblem
    {
        const TicTacToeCellValue PLAYER1_SIGN = TicTacToeCellValue.Cross;
        const TicTacToeCellValue PLAYER2_SIGN = TicTacToeCellValue.Circle;

        readonly string[] _title = new string[]
        {
            "▀█▀ █ █▀▀   ▀█▀ ▄▀█ █▀▀   ▀█▀ █▀█ █▀▀",
            "░█░ █ █▄▄   ░█░ █▀█ █▄▄   ░█░ █▄█ ██▄"
        };
        readonly Random _randomNumberGenerator = new Random();

        ITicTacToeBoard _ticTacToeBoard;
        IPlayer _player1;
        IPlayer _player2;
        IPlayer _currentPlayer;

        public void Execute()
        {
            ShowTitle(_title);
            GameMenu();
            InitializeGame();
            StartGameLoop();
            ShowEndMessage();
        }

        private void GameMenu()
        {
            Console.WriteLine("Do you know how to play? (y/n): ");
            var response = Console.ReadLine().Trim();
            if (!response.Equals("y"))
                ShowManual();
        }
        private void ShowManual()
        {
            //TODO Create the manual.
            LogErrorMessage("No manual yet!");
        }
        private void InitializeGame()
        {
            Console.WriteLine("Please write the name of the P1: ");
            _player1 = new HumanPlayer(Console.ReadLine().Trim(), PLAYER1_SIGN);

            Console.WriteLine("One player mode? (y/n): ");
            var response = Console.ReadLine().Trim();
            bool useBot = response.Equals("y");
            if (useBot)
            {
                Console.WriteLine("Lonely eh? I got you, let's play a game!");
                _player2 = new BotPlayer("BOT", TicTacToeCellValue.Circle);
            }
            else
            {
                Console.WriteLine("Please write the name of the P2: ");
                _player2 = new HumanPlayer(Console.ReadLine().Trim(), PLAYER2_SIGN);
            }

            _currentPlayer = DeterminePlayerToStart();
            _ticTacToeBoard = new TicTacToeBoard();
        }

        private IPlayer DeterminePlayerToStart()
        {
            bool player1GoesFirst = _randomNumberGenerator.Next(2) == 1;

            if (player1GoesFirst)
                return _player1;
            return _player2;
        }

        private void StartGameLoop()
        {
            while (!_ticTacToeBoard.IsBoardFull)
            {
                SubDivision();
                _ticTacToeBoard.ShowBoard();
                _currentPlayer.MakeMove(_ticTacToeBoard);

                if (_ticTacToeBoard.IsThereAWinner)
                    break;
                ChangeTurn();
            }
        }
        private void ChangeTurn() => _currentPlayer = _currentPlayer.Equals(_player1) ? _player2 : _player1;

        private void ShowEndMessage()
        {
            SubDivision();
            if (!_ticTacToeBoard.IsThereAWinner)
                Console.WriteLine("TIE");
            else
                LogSuccessMessage($"{_currentPlayer.Name} WON!");
            _ticTacToeBoard.ShowBoard();
        }
    }
}