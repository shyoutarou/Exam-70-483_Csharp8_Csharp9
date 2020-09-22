using System;

namespace C8_InterpolatedString
{
    class Program
    {
        static void Main(string[] args)
        {
            string szName = "ABC";
            int iCount = 15;

            //Olá, ABC! Você tem 15 maçãs
            Console.WriteLine($"Olá, {szName}! Você tem {iCount} maçãs");
            Console.WriteLine($@"Olá, {szName}! Você tem {iCount} maçãs");
            Console.WriteLine(@$"Olá, {szName}! Você tem {iCount} maçãs");


            int Base = 40;
            int Height = 80;
            int area = (Base * Height) / 2;
            Console.WriteLine("Finding the area of a triangle:");

            // Here, $ token appears before @ token 
            Console.WriteLine($@"Height = ""{Height}"" and Base = ""{Base}""");

            // Here, @ token appears before $ token 
            Console.WriteLine(@$"Area = ""{area}""");

            Console.ReadKey();
        }
    }
}
