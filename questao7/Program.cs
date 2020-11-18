using System;
using System.Collections.Generic;

namespace questao7
{
    class Program
    {
        static void InverteMenorParaMaior(int[] numeros){
            int aux;

            for (int i = numeros.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (numeros[j] > numeros[j + 1])
                    {
                        //efetua a troca de valores
                        aux = numeros[j];
                        numeros[j] = numeros[j + 1];
                        numeros[j + 1] = aux;
                    }
                }
            }
        }

        static void InverteMaiorParaMenor(int[] numeros){
            int aux;

            for (int i = numeros.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (numeros[j] < numeros[j + 1])
                    {
                        //efetua a troca de valores
                        aux = numeros[j];
                        numeros[j] = numeros[j + 1];
                        numeros[j + 1] = aux;
                    }
                }
            }
        }

        static int ConverteParaMenorInteiro(int numero){
            var stringNumeros = numero.ToString().Replace("-", "");
            List<int> listaNumeros = new List<int>();
            bool numeroPositivo = true;

            for (int i = 0; i < stringNumeros.Length; i++)
            {
                listaNumeros.Add(Convert.ToInt32(stringNumeros[i].ToString()));
            }

            var numeros = listaNumeros.ToArray();

            if(numero > 0){
                InverteMenorParaMaior(numeros);
            }
            else{
                InverteMaiorParaMenor(numeros);
                numeroPositivo = false;
            }

            return ConverteParaInteiro(numeros, numeroPositivo);
        }

        static int ConverteParaInteiro(int[] numeros, bool numeroPositivo)
        {
            var valor = string.Join("", numeros);
            var numero = Convert.ToInt32(valor);
            return numeroPositivo ? numero : numero * -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Valor = {ConverteParaMenorInteiro(9056046)}");
            Console.WriteLine($"Valor = {ConverteParaMenorInteiro(6010)}");
            Console.WriteLine($"Valor = {ConverteParaMenorInteiro(11)}");
            Console.WriteLine($"Valor = {ConverteParaMenorInteiro(0)}");
            Console.WriteLine($"Valor = {ConverteParaMenorInteiro(-9056046)}");
            Console.WriteLine($"Valor = {ConverteParaMenorInteiro(-10)}");
            Console.WriteLine($"Valor = {ConverteParaMenorInteiro(-16010)}");
        }
    }
}
