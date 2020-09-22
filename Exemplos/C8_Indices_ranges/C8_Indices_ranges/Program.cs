using System;
using System.Collections.Generic;
using System.Linq;

namespace C8_Indices_ranges
{
    class Program
    {
        static void Main(string[] args)
        {
            //ANTERIORMENTE
            var numbers = Enumerable.Range(1, 10).ToArray();
            var lastItem = numbers[numbers.Length - 1];

            var (start, end) = (1, 7);
            var length = end - start;

            // Using LINQ
            var subset1 = numbers.Skip(start).Take(length);
            Console.WriteLine(string.Join(" ", subset1));

            // Or using Array.Copy
            var subset2 = new int[length];
            Array.Copy(numbers, start, subset2, 0, length);
            Console.WriteLine(string.Join(" ", subset2));

            //Csharp 8
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0

            Console.WriteLine($"The last word is {words[^1]}"); //The last word is dog

            Console.WriteLine(string.Join(" ", words[1..4])); //quick brown fox

            Console.WriteLine(string.Join(" ", words[^2..^0])); //lazy dog

            //The quick brown fox jumped over the lazy dog
            Console.WriteLine(string.Join(" ", words[..]));

            Console.WriteLine(string.Join(" ", words[..4])); //The quick brown fox

            Console.WriteLine(string.Join(" ", words[6..])); //the lazy dog

            Range range = 1..4;
            Console.WriteLine(string.Join(" ", words[range])); //quick brown fox

            var array = new[] { 0, 1, 2, 3, 4, 5 };
            var span = array.AsSpan(1, 4); // = { 1, 2, 3, 4 }
            var subSpan = span[1..^1]; // = { 2, 3 }

            var substring = "Thequickbrownfoxjumpedoverthelazydog"[range];
            Console.WriteLine(substring); //"heq"

            Console.ReadKey();
        }

    }
}
