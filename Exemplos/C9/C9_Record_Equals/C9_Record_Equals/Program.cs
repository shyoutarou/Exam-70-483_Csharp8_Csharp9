using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace C9_Record_Equals
{

    public record Teacher : Person, IEquatable<Person>
    {
        public string Subject { get; init; }
        public decimal Price { get; init; }

        public void Teachclass() => Console.WriteLine("It's class teaching time");

        public bool Equals([AllowNull] Person other)
        {
            throw new NotImplementedException();
        }

        public Teacher(string first, string last, string sub, decimal price)
            : base(first, last) => (Subject, Price) = (sub, price);
    }

    public record Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string FavoriteColor { get; init; }

        //public string LastName { get; }
        //public string FirstName { get; }

        //public string Address;
        //public string City;
        //public string FavoriteColor;

        public Person(string firstName, string lastName, string address, string city, string favoriteColor)
            => (FirstName, LastName, Address, City, FavoriteColor) = (firstName, lastName, address, city, favoriteColor);

        public Person(string first, string last) => (FirstName, LastName) = (first, last);

        protected virtual Type EqualityContract
        {
            [CompilerGenerated]
            get
            {
                return typeof(Person);
            }
        }


        public static bool operator !=(Person r1, Person r2)
        {
            return !(r1 == r2);
        }

        public static bool operator ==(Person r1, Person r2)
        {
            return (object)r1 == r2 || (r1?.Equals(r2) ?? false);
        }

        public override int GetHashCode()
        {
            return ((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295
                    + EqualityComparer<string>.Default.GetHashCode(FirstName)) * -1521134295
                    + EqualityComparer<string>.Default.GetHashCode(Address)) * -1521134295
                    + EqualityComparer<string>.Default.GetHashCode(LastName);
        }
    }

    record Registro
    {
        public int X { get; init; }
        public int Y { get; init; }
    }

    class Classe
    {
        public int X { get; init; }
        public int Y { get; init; }
    }

    struct Estrutura
    {
        public int X { get; init; }
        public int Y { get; init; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Registro reg = new Registro() { X = 3, Y = 4 };
            Registro reg2 = new Registro() { X = 3, Y = 4 };
            Classe cla = new Classe() { X = 3, Y = 4 };
            Classe cla2 = new Classe() { X = 3, Y = 4 };
            Estrutura stu = new Estrutura() { X = 3, Y = 4 };
            Estrutura stu2 = new Estrutura() { X = 3, Y = 4 };

            Console.WriteLine("Registro Equals: " + reg.Equals(reg2)); //value-based equality: True 
            Console.WriteLine("Classe Equals: " + cla.Equals(cla2)); //reference: False
            Console.WriteLine("Estrutura Equals: " + stu.Equals(stu2)); //value-based equality: True



            var person = new Person("Tony", "Stark", "10880 Malibu Point", "Malibu", "red");

            var newPerson = person with { FirstName = "Howard", City = "Pasadena" };

            Console.WriteLine(Object.ReferenceEquals(person, newPerson)); // false
            Console.WriteLine(Object.Equals(person, newPerson)); // false

            var anotherPerson = newPerson with { FirstName = "Tony", City = "Malibu" };
            Console.WriteLine(Object.ReferenceEquals(person, anotherPerson)); // false
            Console.WriteLine(Object.Equals(person, anotherPerson)); // true

            Console.ReadKey();
        }
    }
}
