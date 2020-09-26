using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C8_TaskEnumerableProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            EscreverForeach();
            EscreverForeachAsync();
            Console.ReadLine();
        }

        public static async void EscreverForeach()
        {
            foreach (var dataPoint in await FetchIOTData())
            {
                Console.WriteLine("Foreach: " + dataPoint);
            }
        }

        static async Task<IEnumerable<int>> FetchIOTData()
        {
            List<int> dataPoints = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000);//Simulate waiting for data to come through. 
                dataPoints.Add(i);
            }

            return dataPoints;
        }


        public static async void EscreverForeachAsync()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine("ForeachAsync: " + number);
            }
        }

        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }
}
