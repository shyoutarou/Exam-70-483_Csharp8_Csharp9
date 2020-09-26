using System;

namespace C9_FuncaoAnonimaEstatica
{
    class Program
    {
        Func<int, int, int> subtrai_func = SubtraiNumbers;
        public static int SubtraiNumbers(int a, int b)
        {
            var subtrai = a - b;
            return subtrai;
        }


        static void Main(string[] args)
        {
            int y = 10;
            someMethod(x => x + y); // captures 'y', causing unintended allocation.

            //someMethod(static x => x + y); // error!

            const int z = 10;
            someMethod(static x => x + z);
        }

        private static void someMethod(Func<int, int> soma_func)
        {
            Console.WriteLine(soma_func(2));//12
            Console.WriteLine(soma_func(12));//22
        }
    }
}
