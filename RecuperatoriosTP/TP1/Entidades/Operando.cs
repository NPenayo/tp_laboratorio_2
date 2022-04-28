using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando():this(0)
        {
        }
        public Operando(double numero) : this(numero.ToString())
        {
   
        }
        public Operando(string numero)
        {
            Numero = numero;
        }
        private string Numero { set { this.numero = ValidarOperando(value); } }
        /// <summary>
        /// Corroborar que el operando sea válido
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Si es inválido devuelve 0</returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double input))
            {
                return input;
            }
            return 0;
        }
        /// <summary>
        /// Corroborar que el numero este compuesto solo por "0" y "1"
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            foreach (char digito in binario)
            {
                if (digito != '0' && digito != '1')
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Convertir un numero binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Si no es un numero binario devuelve "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int resultado = 0;
                int exponente = 0;
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    int digito = binario[i] - 48;
                    int potencia = (int)Math.Pow(2, exponente);
                    resultado += digito * potencia;
                    exponente++;
                }
                return resultado.ToString();
            }
            return "Valor inválido";
        }
        /// <summary>
        /// Convertir un numero decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Si no es un numero binario devuelve "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            if (int.TryParse(numero, out int numeroIngresado) && numeroIngresado > 0)
            {
                string resultado = "";
                string digito;
                string invertido = "";
                int indice = 0;
                int divisor = numeroIngresado;
                while (divisor >= 2)
                {
                    digito = (divisor % 2).ToString();
                    divisor = divisor / 2;
                    resultado += digito;
                    if (divisor < 2)
                    {
                        resultado += divisor;
                    }
                    indice++;
                    //if(divisor == 2)
                    //{
                    //    resultado = resultado + digito;
                    //    resultado = resultado + divisor/2;
                    //}
                }
                for (int i = resultado.Length-1; i >= 0; i--)
                {
                    int j = 0;
                    invertido = invertido + resultado[i].ToString();
                    j++;
                }

                return invertido;

            }
            else
            {
                return "Valor inválido";
            }
        }
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// Resta entre operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Producto de operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Division de operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        /// <summary>
        /// Suma de operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
