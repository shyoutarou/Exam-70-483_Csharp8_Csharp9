using System;
using System.Collections.Generic;
using System.Linq;

namespace C8_CoalescenciaNula
{
    class Program
    {
        static void Main(string[] args)
        {
            //null coalescing ?? operator
            double? var1 = null;
            double? var2 = 6.66;
            double var3;

            var3 = var1 ?? 9.11;
            Console.WriteLine(" Value of var3: {0}", var3); //Value of var3: 9,11

            var3 = var2 ?? 9.11;
            Console.WriteLine(" Value of var3: {0}", var3); //Value of var3: 6,66

            var3 = var1 ?? double.NaN;
            Console.WriteLine(" Value of var3: {0}", var3); //Value of var3: NaN: 

            double? var4 = null;
            var4 = var1 ?? var4;
            Console.WriteLine(" Value of var4: {0}", var3); //Value of var4: 

            //var3 = var1 ?? var4;
            //Console.WriteLine(" Value of var3: {0}", var3); 



            int? number = null;
            number = number ?? 0;


            //int number2 = 5;
            //number = number2 ?? 0;


            //Chasrp 8
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            Console.WriteLine(i);  // output: 17

            numbers.Add(i ??= 20);
            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.ReadKey();
        }

        //parâmetro de tipo genérico irrestrito 
        private static void Display<T>(T a, T backup)
        {
            Console.WriteLine(a ?? backup);
        }


        private static double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
        }


        private static void Cenario1()
        {
            //Fornecer uma expressão alternativa a ser avaliada, caso 
            //o resultado da expressão com operações condicionais nulas seja null:
            var sum = SumNumbers(null, 0);
            Console.WriteLine(sum);  // output: NaN
        }

        private static void Cenario2()
        {
            //Fornecer um valor de um tipo de valor subjacente, caso um valor de 
            //tipo anulável seja null : :
            int? a = null;
            int b = a ?? -1;
            Console.WriteLine(b);  // output: -1
        }

        //Usar uma expressão throw como o operando à direita do ?? operador para
        //tornar o código de verificação de argumento mais conciso.
        private string name;
        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
        }

        
        private static void Cenario3()
        {
            List<int> numbers = null;
            int? variable = null;
            int expression = 5;

            if (variable is null)
            {
                variable = expression;
            }

            (numbers = numbers ?? new List<int>()).Add(5);
            numbers.Add((variable = variable ?? 0).Value);

            //A partir do C# 8,0, compara e atribui valor 
            variable ??= expression;

            (numbers ??= new List<int>()).Add(5);
            numbers.Add(variable ??= 0);
        }

    }
}
