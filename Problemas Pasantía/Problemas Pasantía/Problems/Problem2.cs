using System;
using static ConsoleUtilitiesLite.ConsoleUtilitiesLite;

//Es posible que conozcas algunos cuadrados perfectos bastante grandes. Pero, ¿qué pasa con el próximo?
//Realice una función que encuentra el siguiente cuadrado perfecto integral después del que pasó como parámetro.
//Recuerde que un cuadrado perfecto integral es un entero n tal que sqrt (n) también es un entero.
//Si el parámetro en sí mismo no es un cuadrado perfecto, debe devolverse -1. Puede suponer que el parámetro es positivo.
//EJEMPLOS:
//121 -- > returns 144
//625 -- > returns 676
//114 -- > returns - 1 since 114 is not a perfect square.

namespace Problemas_Pasantía
{
    internal class Problem2 : IProblem
    {
        readonly string[] title = new string[]
        {
            "█▄░█ █▀▀ ▀▄▀ ▀█▀   █▀█ █▀▀ █▀█ █▀▀ █▀▀ █▀▀ ▀█▀   █▀ █▀█ █░█ ▄▀█ █▀█ █▀▀",
            "█░▀█ ██▄ █░█ ░█░   █▀▀ ██▄ █▀▄ █▀░ ██▄ █▄▄ ░█░   ▄█ ▀▀█ █▄█ █▀█ █▀▄ ██▄"
        };

        public void Execute()
        {
            ShowTitle(title);
            Console.WriteLine("Please write a number.");
            string response = Console.ReadLine().Trim();

            int nextPerfectSquare = CalculateNextPerfectSquare(response);

            ShowNextPerfectSquare(response, nextPerfectSquare);
        }

        private static int CalculateNextPerfectSquare(string response)
        {
            if (double.TryParse(response, out double number))
            {
                if (!NumberIsPerfectSquare(number, out int squareRoot))
                    return -1;

                return (int)Math.Pow(squareRoot + 1, 2f);
            }
            return -1;
        }

        private static bool NumberIsPerfectSquare(double number, out int squareRootOfNumber)
        {
            squareRootOfNumber = 0;
            double squareRoot = Math.Sqrt(number);

            if (!NumberIsInteger(number))
                return false;

            if (!NumberIsInteger(squareRoot))
                return false;

            squareRootOfNumber = (int)squareRoot;
            return true;
        }

        //Como double es un tipo de punto flotante no existe la igualdad, así que esta es una adaptación de la forma original
        // (number%1==0) para acomodar esta característica.
        private static bool NumberIsInteger(double number) => (number % 1) <= double.Epsilon * 100;
        private void ShowNextPerfectSquare(string response, int nextPerfectSquare) => Console.WriteLine($"{response} => {nextPerfectSquare:N}");
    }
}