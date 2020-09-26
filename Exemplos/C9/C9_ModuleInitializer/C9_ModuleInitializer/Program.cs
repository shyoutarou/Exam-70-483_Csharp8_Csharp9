using System;
using System.Runtime.CompilerServices;

namespace C9_ModuleInitializer
{

    class C
    {
        [ModuleInitializer]
        internal static void M1()
        {
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
