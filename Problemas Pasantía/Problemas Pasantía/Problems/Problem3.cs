using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ConsoleUtilitiesLite.ConsoleUtilitiesLite;

//Realice una función que reciba un número entero positivo menor o igual que 200,
//y retorne su representación en palabras.
//No puede implementar librerías ni funciones que no hayan sido hechas por usted.
//EJEMPLO:
//228
//two hundred and twenty eight

namespace Problemas_Pasantía
{
    internal class Problem3 : IProblem
    {
        readonly string[] title = new string[]
        {
            "█▄░█ █░█ █▀▄▀█ █▄▄ █▀▀ █▀█   ▀█▀ █▀█   █░█░█ █▀█ █▀█ █▀▄",
            "█░▀█ █▄█ █░▀░█ █▄█ ██▄ █▀▄   ░█░ █▄█   ▀▄▀▄▀ █▄█ █▀▄ █▄▀"
        };

        #region Translators
        private readonly Dictionary<char, string> normalDigitTranslator = new Dictionary<char, string>()
        {
            {'1', "one" },
            {'2', "two" },
            {'3', "three" },
            {'4', "four" },
            {'5', "five" },
            {'6', "six" },
            {'7', "seven" },
            {'8', "eight" },
            {'9', "nine" }
        };
        private Dictionary<char, string> tenthsTranslator = new Dictionary<char, string>()
        {
            {'2', "twenty" },
            {'3', "thirty" },
            {'4', "forty" },
            {'5', "fifty" },
            {'6', "sixty" },
            {'7', "seventy" },
            {'8', "eighty" },
            {'9', "ninety" }
        };
        private Dictionary<char, string> tenthTranslator = new Dictionary<char, string>()
        {
            {'0', "ten" },
            {'1', "eleven" },
            {'2', "twelve" },
            {'3', "thirdteen" },
            {'4', "fourteen" },
            {'5', "fifteen" },
            {'6', "sixteen" },
            {'7', "seventeen" },
            {'8', "eighteen" },
            {'9', "nineteen" }
        };
        #endregion

        public void Execute()
        {
            ShowTitle(title);
            while (true)
            {
                LogInfoMessage("It can actually handle from 0 to 999, but you need to change the limit variable to 999.");
                int limit = 200;

                Console.WriteLine($"Please write a number (0-{limit}).");
                string response = Console.ReadLine().Trim();
                if (int.TryParse(response, out int number) && number >= 0 && number <= limit)
                {
                    string numberInLetters = ConvertToLeters(number.ToString());//Si ingresan 00, esto devuelve 0, así como 03 a 3.
                    ShowResult(number, numberInLetters);
                    break;
                }

                LogErrorMessage("Please write a valid number!");
            }
        }

        private string ConvertToLeters(string number)
        {
            if (number.Equals("0"))
                return "zero";

            List<string> numberInLetters = new List<string>();
            char[] numberInReverse = number.Reverse().ToArray();
            char previousDigit = '0';

            for (int i = 0; i < numberInReverse.Length; i++)
            {
                char digit = numberInReverse[i];
                if (digit.Equals('0'))
                {
                    previousDigit = '0';
                    continue;
                }

                //También añade el "and" si es necesario.
                AddHundredPrefixIfNeeded(numberInLetters, previousDigit, i);

                bool numberHas2Digits = i == 1;
                if (numberHas2Digits)
                {
                    bool numberIsBetween10And19 = int.Parse($"{digit}") == 1;
                    if (numberIsBetween10And19)
                    {
                        numberInLetters.Clear();
                        numberInLetters.Add(tenthTranslator[previousDigit]);
                        continue;
                    }
                    numberInLetters.Add(tenthsTranslator[digit]);
                    continue;
                }

                numberInLetters.Add(normalDigitTranslator[digit]);
                previousDigit = digit;
            }

            numberInLetters.Reverse();
            return string.Join(' ', numberInLetters);
        }

        private static void AddHundredPrefixIfNeeded(List<string> numberInLetters, char previousDigit, int i)
        {
            if (i != 2)
                return;
            //si es número divisible exactamente dentro de 100, como 200, 300, etc...
            bool numberIsExactHundred = previousDigit.Equals('0');
            if (!numberIsExactHundred)
                numberInLetters.Add("and");
            numberInLetters.Add("hundred");
        }
        private void ShowResult(int number, string numberInLetters) => Console.WriteLine($"{number} => {numberInLetters}");
    }
}