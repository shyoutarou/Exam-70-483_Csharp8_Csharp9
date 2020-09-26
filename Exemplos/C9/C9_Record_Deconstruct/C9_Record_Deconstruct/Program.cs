using System;
using System.Text;

namespace C9_Record_Deconstruct
{
    public record Person
    {
        public string LastName { get; }
        public string FirstName { get; }

        public string Address;
        public string City;
        public string FavoriteColor;

        public Person(string firstName, string lastName, string address, string city, string favoriteColor)
            => (FirstName, LastName, Address, City, FavoriteColor) = (firstName, lastName, address, city, favoriteColor);
        public Person(string first, string last) => (FirstName, LastName) = (first, last);

        public void Deconstruct(out string firstName, out string lastName, out string address,
                        out string city, out string favoriteColor)
                => (firstName, lastName, address, city, favoriteColor) = (FirstName, LastName, Address, City, FavoriteColor);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Bill", "Wagner");
            var (first, last, address, city, color) = person;

            Console.WriteLine(person.FirstName); // Bill
            Console.WriteLine(person.LastName); // Wagner
            Console.WriteLine(first); // Bill
            Console.WriteLine(last); // Wagner
            Console.WriteLine(address); // 
            Console.WriteLine(city); // 
            Console.WriteLine(color); // 

            var hero = new Person("Tony", "Stark", "10880 Malibu Point", "Malibu", "red");
            var (firsth, lasth, addressh, cityh, colorh) = hero;

            Console.WriteLine(hero.FirstName); // Tony
            Console.WriteLine(hero.LastName); // Stark
            Console.WriteLine(firsth); // Tony
            Console.WriteLine(lasth); // Stark
            Console.WriteLine(addressh); // 10880 Malibu Point
            Console.WriteLine(cityh); // Malibu
            Console.WriteLine(colorh); // red

            Console.ReadKey();
        }
    }
}
