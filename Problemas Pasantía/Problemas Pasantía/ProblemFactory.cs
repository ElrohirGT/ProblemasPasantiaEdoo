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
                case 2:
                    return new Problem2();
                case 3:
                    return new Problem3();
                //case 4:
                //    return new Problem4();
                default:
                    return null;
            }
        }
    }
}
