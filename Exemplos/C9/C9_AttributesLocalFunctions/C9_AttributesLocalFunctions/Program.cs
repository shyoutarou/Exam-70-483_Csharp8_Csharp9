using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace C9_AttributesLocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 5, num2 = 7;

            static int Sum(int x, int y)
            {
                return x + y;
            };
            var result = Sum(num1, num2);
            Console.WriteLine(result); //12


            int Sum2() => num1 + num2;
            var resultsum = Sum2();
            Console.WriteLine(resultsum); //12

            Sum_C9(num1, num2);

            [Conditional("DEBUG")]
            static void Sum_C9([NotNull] int x, [NotNull] int y)
            {
                Console.WriteLine(x + y); //12
            }
        }

        public static IAsyncEnumerable<int> Where(this IAsyncEnumerable<int> source, Func<int, int> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return Core();

            async IAsyncEnumerable<int> Core([EnumeratorCancellation] CancellationToken token = default)
            {
                await foreach (var item in source.WithCancellation(token))
                {
                    if (predicate(item) == 1)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
