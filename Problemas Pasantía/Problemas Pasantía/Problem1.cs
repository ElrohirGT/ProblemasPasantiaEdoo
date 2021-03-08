using System;
using System.Linq;
using static ConsoleUtilitiesLite.ConsoleUtilitiesLite;

//Escriba una función que tome una cadena de una o más palabras y devuelva la misma cadena,
//pero con las palabras de las cinco o más letras invertidas.
//Las cadenas aprobadas consistirán solo de letras y espacios.
//Los espacios se incluirán sólo cuando haya más de una palabra presente.
//EJEMPLOS:
//"Hey fellow warriors" => "Hey wollef sroirraw"
//"This is a test" => returns "This is a test"
//"This is another test" => returns "This is rehtona test"

namespace Problemas_Pasantía
{
    internal class Problem1 : IProblem
    {
        readonly string[] title = new string[2]
        {
            "█▀ █▀█ █ █▄░█ █▄░█ █ █▄░█ █▀▀ █▀   █░█░█ █▀█ █▀█ █▀▄ █▀",
            "▄█ █▀▀ █ █░▀█ █░▀█ █ █░▀█ █▄█ ▄█   ▀▄▀▄▀ █▄█ █▀▄ █▄▀ ▄█"
        };

        public void Execute()
        {
            ShowTitle(title);
            Console.WriteLine("Please write a sentence.");
            string response = Console.ReadLine().Trim();
            
            string returnedSentence = EvaluateSentence(response);
            ShowConvertedSentence(response, returnedSentence);
        }

        private static string EvaluateSentence(string response)
        {
            string resultString = "";
            foreach (var word in response.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                if (string.IsNullOrEmpty(word))
                    continue;

                if (word.Length < 5)
                {
                    resultString += word;
                    continue;
                }

                if (resultString.Length != 0)
                    resultString += " ";

                char[] inversedWordChars = word.Reverse().ToArray();
                resultString += new string(inversedWordChars);//new string necesita un array, no un Enumerable.
            }
            return resultString;
        }

        private static void ShowConvertedSentence(string before, string after) => Console.WriteLine($"{before} => {after}");
    }
}
