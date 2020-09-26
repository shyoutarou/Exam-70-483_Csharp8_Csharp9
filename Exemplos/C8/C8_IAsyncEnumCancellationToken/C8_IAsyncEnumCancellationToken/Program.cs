using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace C8_IAsyncEnumCancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EscreverForeachAsync();

                Console.ReadKey();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro:" + erro.Message);
            }
        }


        public static async void EscreverForeachAsync()
        {
            try
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(0.2));
                //Pode ser dos 2 jeitos abaixo, Passar o token diretamente para o método é mais fácil, mas não funciona 
                //quando você recebe um IAsyncEnumerable <T> arbitrário de alguma outra fonte, dai usa-se o WithCancellation
                //await foreach (var number in RangeAsync(1, 10).WithCancellation(cts.Token).ConfigureAwait(false))
                await foreach (var number in RangeAsync(1, 10, cts.Token).ConfigureAwait(false))
                {
                    Console.WriteLine("Foreach: " + number);
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro:" + erro.Message);
            }   
        }


        static async IAsyncEnumerable<int> RangeAsync(int start, int count,
                [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            for (int i = 0; i < count; i++)
            {
                await Task.Delay(i, cancellationToken);
                yield return start + i;
            }
        }
    }
}
