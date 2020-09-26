using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace C8_AsyncStreams
{

    //public interface IAsyncEnumerable<out T>
    //{
    //    IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);
    //}

    //public interface IAsyncEnumerator<out T> : IAsyncDisposable
    //{
    //    T Current { get; }

    //    ValueTask<bool> MoveNextAsync();
    //}

    //public interface IAsyncDisposable
    //{
    //    ValueTask DisposeAsync();
    //}

    class Program
    {
        static void Main(string[] args)
        {
            EscreverWhileAsync();
            EscreverForeachAsync();
            Console.ReadKey();
        }

        public static async void EscreverForeachAsync()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine("Foreach: " + number);
            }
        }

        public static async void EscreverWhileAsync()
        {
            var asyncEnumerator = GenerateSequence().GetAsyncEnumerator();
            try
            {
                while (await asyncEnumerator.MoveNextAsync())
                {
                    var value = asyncEnumerator.Current;
                    Console.WriteLine("While: " + value);
                }
            }
            finally
            {
                await asyncEnumerator.DisposeAsync();
            }
        }

        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

    }
}
