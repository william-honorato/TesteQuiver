using System;
using System.Collections.Generic;
using System.Linq;

namespace questao6
{
    class Program
    {
        const int NUMERO_MINIMO = 1;
        const int NUMERO_MAXIMO = 60;
        const int NUMERO_DE_CARTELAS = 20;
        const int NUMERO_MAX_REPETICAO_POR_CARTELA = 4;
        const int QUANTIDADE_NUMEROS_POR_CARTELA = 6;
        static List<List<int>> ListaCartelas = new List<List<int>>();
        
        static bool VerificarSeCartelaValida(List<int> numeros){

            foreach (var cartela in ListaCartelas)
            {
                List<int> listaAux = new List<int>();
                listaAux.AddRange(cartela);
                listaAux.AddRange(numeros);
                var qtdNumerosDiferentes = listaAux.Distinct().Count();

                var numeroMaxRepeticoes = (2 * QUANTIDADE_NUMEROS_POR_CARTELA) - NUMERO_MAX_REPETICAO_POR_CARTELA;

                if(qtdNumerosDiferentes < numeroMaxRepeticoes) return false;
            }

            return true;
        }

        static List<int> GerarNumerosAleatoriosDistintos(int qtdNumeros){
            List<int> numeros = new List<int>();
            Random rnd = new Random();

            while(numeros.Count < qtdNumeros){
                var num = rnd.Next(NUMERO_MINIMO, NUMERO_MAXIMO+1);
                if(!numeros.Contains(num)) numeros.Add(num);
            }
            return numeros;
        }

        static List<int> GerarCartelaValida(){
            var novaCartela = new List<int>();
            bool cartelaValida = false;

            while(!cartelaValida){
                novaCartela = GerarNumerosAleatoriosDistintos(QUANTIDADE_NUMEROS_POR_CARTELA);
                cartelaValida = VerificarSeCartelaValida(novaCartela);
            }

            novaCartela.Sort();
            return novaCartela;
        }

        static void GerarCartelas(int qtdCartelas){
            for (int i = 1; i <= qtdCartelas; i++)
            {
                var cartela = GerarCartelaValida();
                ListaCartelas.Add(cartela);
            }
        }

        static void Main(string[] args)
        {
            int i = 1;
            GerarCartelas(NUMERO_DE_CARTELAS);
            
            foreach (var cartela in ListaCartelas)
            {
                var numerosGerados = string.Join("-", cartela.ToArray());
                Console.WriteLine($"Cartela {i++} = {numerosGerados}");
            }
        }
    }
}
