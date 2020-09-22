using System;

namespace C8_FuncaoLocalEstatica
{
    class Program
    {
        static void Main(string[] args)
        {
            var funcoes = new Funcoes();

            var retorno = funcoes.M();
            Console.WriteLine("Função M: " + retorno); //Função M: 0


            retorno = funcoes.M_Est();
            Console.WriteLine("Função M_Est: " + retorno); //Função M_Est: 12

            Console.ReadKey();
        }

        class Funcoes
        {
            public int M()
            {
                int y;
                LocalFunction();
                return y;

                void LocalFunction() => y = 0;
            }

            public int M_Est()
            {
                int y = 5;
                int x = 7;
                return Add(x, y);

                static int Add(int left, int right) => left + right;
            }
        }


    }
}
