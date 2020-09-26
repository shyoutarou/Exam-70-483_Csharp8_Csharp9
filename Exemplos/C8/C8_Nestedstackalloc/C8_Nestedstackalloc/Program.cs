using System;

namespace C8_Nestedstackalloc
{
    class Program
    {
        static void Main(string[] args)
        {

            //Antes do C# 7,2
            unsafe
            {
                int* Array1 = stackalloc int[3] { 5, 6, 7 };
            }

            Span<int> Array = stackalloc[] { 10, 20, 30 };


            //A partir do C# 7,2
            int length = 3;
            Span<int> numbers7_2 = stackalloc int[length];
            for (var i = 0; i < length; i++)
            {
                numbers7_2[i] = i;
            }

            //C# 7,3, Limite a quantidade de memória 
            //uso de stackalloc em condicional ou expressões de atribuição
            length = 1000;
            const int MaxStackLimit = 1024;
            Span<byte> buffer = length <= MaxStackLimit ? stackalloc byte[length] : new byte[length];

            //C# 7,3, sintaxe do inicializador de matriz
            Span<int> first = stackalloc int[3] { 1, 2, 3 };
            Span<int> second = stackalloc int[] { 1, 2, 3 };
            ReadOnlySpan<int> third = stackalloc[] { 1, 2, 3 };


            //C# 8
            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
            Console.WriteLine(ind);  // output: 1

            Span<int> num = stackalloc[] { 20, 30, 40 };
            var index = num.IndexOfAny(stackalloc[] { 20 });
            Console.WriteLine(index);  // output: 0


            //sintaxe tipo de ponteiro
            unsafe
            {
                int lengthpont = 3;
                int* numberspont = stackalloc int[lengthpont];
                for (var i = 0; i < lengthpont; i++)
                {
                    numberspont[i] = i;
                }
            }

            Console.ReadKey();
        }
    }
}
