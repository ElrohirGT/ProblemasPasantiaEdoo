using System;

namespace Problemas_Pasantía
{
    internal class ProblemFactory
    {
        internal static IProblem CreateFrom(int numberSelected)
        {
            //Acá se podría usar Reflection para poder crear la clase dinámicamente dependiendo del número que haya seleccionado
            //sin embargo creo que eso ya sería overkill.
            switch (numberSelected)
            {
                case 1:
                    return new Problem1();
                case 2:
                    return new Problem2();
                case 3:
                    return new Problem3();
                case 4:
                    return new Problem4();
                default:
                    return null;
            }
        }
    }
}
