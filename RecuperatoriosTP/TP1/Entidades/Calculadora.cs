using System;

namespace Entidades
{
    public static class Calculadora
    {   
        /// <summary>
        /// Corroborar que el operador sea válido
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Si no es un operador válido setea +</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '-' && operador != '+' && operador != '*' && operador != '/')
            {
                return '+';
            }
            else
            {
                return operador;
            }
        }
        /// <summary>
        /// Realiza una operación entre dos operandos
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
