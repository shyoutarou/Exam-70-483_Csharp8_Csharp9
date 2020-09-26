using System;
using System.Runtime.CompilerServices;

namespace C9_SkipLocals
{
    //interface ICounter
    //{
    //    void Increment();
    //}

    //struct Counter : ICounter
    //{
    //    int value;

    //    public override string ToString()
    //    {
    //        return value.ToString();
    //    }

    //    void ICounter.Increment()
    //    {
    //        value++;
    //    }
    //}

    struct Counter
    {
        int value;

        public override string ToString()
        {
            return value.ToString();
        }

        public void Increment()
        {
            value++;
        }
    }

    class Program
    {


        //static void Test<T>() where T : ICounter, new()
        //{
        //    T x = new T();
        //    Console.WriteLine(x);
        //    x.Increment();                    // Modify x
        //    Console.WriteLine(x);
        //    x.Increment();                    // Modify x
        //    Console.WriteLine(x);
        //    ((ICounter)x).Increment();        // Modify boxed copy of x
        //    Console.WriteLine(x);
        //}


        static void Main(string[] args)
        {

            //Counter x = new Counter();
            //Console.WriteLine(x);
            //x.Increment();                    // Modify x
            //Console.WriteLine(x);
            //x.Increment();                    // Modify x
            //Console.WriteLine(x);
            //((Counter)x).Increment();        // Modify boxed copy of x
            //Console.WriteLine(x);

            //Test<Counter>();


            for (int i = 0; i < 10; i++)
            {
                //PrintRunningCount();
                PrintRunningCountStruct();
            }
        }

        //void GiveMeTheLocal()
        //{
        //    int something;
        //    Console.WriteLine(something);
        //}


        [SkipLocalsInit]
        static void PrintRunningCount()
        {
            const int Magic = 123214;
            Span<int> arr = stackalloc int[2];
            if (arr[0] != Magic)
            {
                arr[0] = Magic;
                arr[1] = 0;
            }
            Console.WriteLine($"Hello World stackalloc {arr[1]++}!");
        }


        //struct StackCounter
        //{
        //    public long A;

        //    public static long Increment(ref StackCounter c) { return c.A++; }
        //}

        public struct StackCounter
        {
            public long A;
            public long Count;
            public long Magic;
            public static long Increment(ref StackCounter c)
            {
                const long Magic = 23872139472367;
                if (c.Magic != Magic)
                {
                    c.Magic = Magic;
                    c.Count = 0;
                }

                return c.Count++;
            }
        }

        [SkipLocalsInit]
        static void PrintRunningCountStruct()
        {
            long count;
            StackCounter counter;
            //StackCounter counter = default(StackCounter);
            //StackCounter counter = new StackCounter();

            counter.A = default;
            counter.Count = default;
            counter.Magic = default;
            // counter is definitely assigned since we've set all of it's fields

            count = StackCounter.Increment(ref counter);
            Console.WriteLine($"Hello World {count}!");
        }

    }
}
