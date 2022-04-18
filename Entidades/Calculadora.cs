using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador
        /// </summary>
        /// <param name="operador">Operador ingresado</param>
        /// <returns>Retorna el operador ingresado, en caso de no ser correcto devuelve '+'</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }

            return '+';
        }

        /// <summary>
        /// Realiza la operacion indicada
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>Retorna el resultado de la operacion, si alguno de los operandos son nulos, retorna -1</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double result = -1;

            if (num1 is not null && num2 is not null)
            {
                char operadorAux = ValidarOperador(operador);

                switch (operadorAux)
                {
                    case '+':
                        result = num1 + num2;
                        break;

                    case '-':
                        result = num1 - num2;
                        break;

                    case '*':
                        result = num1 * num2;
                        break;

                    case '/':
                        result = num1 / num2;
                        break;
                }

                return result;

            }

            return result;
        }
    }
}
