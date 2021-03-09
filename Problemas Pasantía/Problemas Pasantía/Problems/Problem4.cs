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
            var response = Console.ReadLine().Trim().ToLower();
            if (!response.Equals("y"))
                ShowManual();
        }
        private void ShowManual()
        {
            Console.Clear();
            TicTacToeBoardExamples boardExamples = new TicTacToeBoardExamples();

            Console.WriteLine("Welcome to Tic Tac Toe, the objective of the game is to make 3 consecutive signs in a line.");
            Console.WriteLine("This is an example where the circle wins.");
            boardExamples.ShowDiagonalWins();
            
            Console.WriteLine("If you want to play against the computer you just need to answer \"y\" to the One player mode question. If you want to play with a friend, just answer \"n\" or press enter.");
            Console.WriteLine("If you choosed multiplayer and after you set your names, you will be asked to input which cell you want to mark with your sign. The correct format for this is row cell. Heres an example:");
            boardExamples.ShowInputExample();

            Console.WriteLine("And that's all you need to know to play de game!");

            LogInfoMessage("Press any key to go back...");
            Console.ReadLine();
            Console.Clear();
        }
        private void InitializeGame()
        {
            Console.WriteLine("Please write the name of the P1: ");
            _player1 = new HumanPlayer(Console.ReadLine().Trim(), PLAYER1_SIGN);

            Console.WriteLine("One player mode? (y/n): ");
            var response = Console.ReadLine().Trim().ToLower();
            bool useBot = response.Equals("y");
            if (useBot)
            {
                Console.WriteLine("Lonely eh? I got you, let's play a game!");
                _player2 = new BotPlayer("BOT", PLAYER2_SIGN);
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