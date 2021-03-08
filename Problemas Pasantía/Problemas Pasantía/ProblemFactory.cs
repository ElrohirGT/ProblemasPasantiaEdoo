using System;

namespace Problemas_Pasantía
{
    internal class ProblemFactory
    {
        internal static IProblem CreateFrom(int numberSelected)
        {
            switch (numberSelected)
            {
                case 1:
                    return new Problem1();
                default:
                    return null;
            }
        }
    }
}
