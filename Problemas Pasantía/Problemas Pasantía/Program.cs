using System;
using static ConsoleUtilitiesLite.ConsoleUtilitiesLite;

namespace Problemas_Pasantía
{
    class Program
    {
        static string[] title = new string[]
        {
            "█▀█ █▀█ █▀█ █▄▄ █░░ █▀▀ █▀▄▀█   █▀▄▀█ █▀▀ █▄░█ █░█",
            "█▀▀ █▀▄ █▄█ █▄█ █▄▄ ██▄ █░▀░█   █░▀░█ ██▄ █░▀█ █▄█"
        };
        static void Main(string[] args)
        {
            ShowHeader();

            while (true)
            {
                LogInfoMessage("Type q/Q to quit the selection menu.");

                Console.Write("Welcome, please write a number between 1-4 to select a problem: ");
                string response = Console.ReadLine().Trim();

                if (response.Equals("q") || response.Equals("Q"))
                    break;

                if (int.TryParse(response, out int numberSelected))
                {
                    IProblem problem = ProblemFactory.CreateFrom(numberSelected);
                    if (problem is null)
                    {
                        LogErrorMessage("No error defined for this number!");
                        continue;
                    }

                    bool continueExecution;
                    do
                    {
                        Console.Clear();
                        problem.Execute();
                        SubDivision();
                        continueExecution = AskToRepeatProblem();
                        
                        if (!continueExecution)
                            ShowHeader();
                    } while (continueExecution);

                    continue;
                }

                LogErrorMessage("Please write a valid number!");
            }
        }

        private static void ShowHeader()
        {
            Console.Clear();
            ShowTitle(title);
        }

        private static bool AskToRepeatProblem()
        {
            bool continueExecution;
            
            Console.Write("Do you want to execute it again? (y/n): ");
            continueExecution = Console.ReadLine().Trim().Equals("y");
            
            return continueExecution;
        }
    }
}
