using System;
using System.Collections.Generic;

namespace C9_NativeSized
{
    public class Country
    {
        public string Name { get; set; }
    }

    public class CountryService
    {
        public Country GetByIndex(Country[] countries, nint index)
        {
            return countries[index]; // legal
        }

        //public Country GetByIndex(List<Country> countries, nint index)
        //{
        //    return countries[index]; // CS1503: cannot convert from 'nint' to int
        //}
    }



    class Program
    {
        static void Main(string[] args)
        {
            nint x = 3;
            int y = 3;
            long v = 10;

            Console.WriteLine(nint.Equals(x, y)); // False
            Console.WriteLine(nint.Equals(x, (nint)y)); // True

            Console.WriteLine(y + 1 > x); // True
            Console.WriteLine(y - 1 == x); // False

            Console.WriteLine(typeof(nint)); // System.IntPtr
            Console.WriteLine(typeof(nuint));  // System.UIntPtr
            Console.WriteLine((x + 1).GetType()); // System.IntPtr
            Console.WriteLine((x + y).GetType()); // System.IntPtr
            Console.WriteLine((x + v).GetType()); // System.Int64

            //RuntimeBinderException: 'Operator '+' cannot be applied to operands of type 'int' and 'System.IntPtr''
            dynamic z = 1;
            var test8 = z + x;
            Console.WriteLine(test8);

            Console.ReadKey();
        }
    }
}
