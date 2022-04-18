using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Valida que el operando sea un numero
        /// </summary>
        /// <param name="strNumero">String a validar</param>
        /// <returns>Retorna el numero en double o retorna cero si no es un numero</returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }

            return 0;
        }

        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }


        /// <summary>
        /// Convierte un decimal en binario
        /// </summary>
        /// <param name="numero">Decimal a convertir</param>
        /// <returns>Retorna el resultado en string</returns>
        public string DecimalBinario(double numero)
        {
            int dividendo = (int)Math.Truncate(numero);
            string retorno = string.Empty;

            dividendo = Math.Abs(dividendo);

            while (dividendo > 0)
            {
                retorno = dividendo % 2 + retorno;
                dividendo /= 2;
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un decimal en binario
        /// </summary>
        /// <param name="strNumero">String a convertir</param>
        /// <returns>Retorna el resultado en string o Valor Invalido si el parametro no es un numero</returns>
        public string DecimalBinario(string strNumero)
        {
            string retorno = "Valor invalido";

            if (double.TryParse(strNumero, out double numero))
            {
                return DecimalBinario(numero);
            }

            return retorno;
        }

        /// <summary>
        /// Valida si un string es binario
        /// </summary>
        /// <param name="binario">Parametro a validar</param>
        /// <returns>Retorna TRUE si el parametro es un binario o FALSE caso contrario</returns>
        private bool EsBinario(string binario)
        {
            if (binario is not null)
            {
                char[] arrayCaracteres = binario.ToCharArray();

                for (int i = 0; i < arrayCaracteres.Length; i++)
                {
                    if (arrayCaracteres[i] != '1' && arrayCaracteres[i] != '0')
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Convierte un numero binario en decimal
        /// </summary>
        /// <param name="binario">Parametro a convertir</param>
        /// <returns>Retorna el resultado de la conversion o Valor Invalido si no se pudo convertir</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";

            if (binario is not null && EsBinario(binario))
            {
                char[] binarioA_Decimal = binario.ToCharArray();
                double potencia = 0;
                double numeroConvertido = 0;

                for (int i = binarioA_Decimal.Length - 1; i >= 0; i--)
                {
                    if (binarioA_Decimal[i] == '1')
                    {
                        numeroConvertido = numeroConvertido + Math.Pow(2, potencia);
                    }
                    potencia++;
                }

                retorno = numeroConvertido.ToString();
                return retorno;
            }

            return retorno;
        }

        /// <summary>
        /// Suma dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1">Primero parametro</param>
        /// <param name="n2">Segundo parametro</param>
        /// <returns>Retorna la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1">Primero parametro</param>
        /// <param name="n2">Segundo parametro</param>
        /// <returns>Retorna la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1">Primero parametro</param>
        /// <param name="n2">Segundo parametro</param>
        /// <returns>Retorna el producto</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1">Primero parametro</param>
        /// <param name="n2">Segundo parametro</param>
        /// <returns>Retorna la division, si el divisor es CERO retorna MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }

            return double.MinValue;
        }
    }
}
