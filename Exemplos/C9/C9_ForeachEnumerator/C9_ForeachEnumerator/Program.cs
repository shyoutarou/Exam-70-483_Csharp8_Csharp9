using System;
using System.Collections.Generic;

namespace C9_ForeachEnumerator
{

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(5);
            list.Add(9);

            List<int>.Enumerator e = list.GetEnumerator();
            Write(e);

            Console.ReadKey();
        }

        static void Write(IEnumerator<int> e)
        {
            while (e.MoveNext())
            {
                int value = e.Current;
                Console.WriteLine(value);
            }
        }
    }
}
