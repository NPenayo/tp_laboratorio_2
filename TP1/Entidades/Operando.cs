using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }
        public Operando(string numero) : this()
        {
            Numero = numero;
        }
        public Operando(double numero) : this()
        {
            Numero = numero.ToString();
        }
        private string Numero { set { this.numero = ValidarOperando(value); } }

        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double input))
            {
                return input;
            }
            return 0;
        }
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
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int resultado = 0;
                for (int i = binario.Length; i >= 0; i++)
                {
                    resultado += (int)binario[i] * (2 ^ i);
                }
                return resultado.ToString();
            }
            return "Valor inválido";
        }
        public string DecimalBinario(string numero)
        {
            if (int.TryParse(numero, out int numeroIngresado) && numeroIngresado > 0)
            {
                char[] resultado = null;
                char digito;
                string invertido;
                int indice = 0;
                int divisor = numeroIngresado;
                while (divisor > 2)
                {
                    digito = (char)(divisor % 2);
                    divisor = divisor / 2;
                    resultado.SetValue(digito, indice);
                    indice++;
                }
                Array.Reverse(resultado);
                invertido = resultado.ToString();

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
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
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
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
