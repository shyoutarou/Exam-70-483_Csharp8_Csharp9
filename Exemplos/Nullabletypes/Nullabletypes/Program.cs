using System;

namespace Nullabletypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int? x = 5;

            if (x.HasValue)
            {
                Console.WriteLine("contain not nullable value: " + x.Value.ToString());
            }
            else
            {
                Console.WriteLine("contain Null value.");
            }

            Console.ReadLine();
        }
    }
}
