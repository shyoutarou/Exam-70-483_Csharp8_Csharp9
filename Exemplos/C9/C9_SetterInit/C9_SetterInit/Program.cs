using System;

namespace C9_SetterInit
{
    public class Person
    {
        public string FirstName { get; init; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string FavoriteColor { get; set; }
        // and so on...
    }


    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "Tony",
                LastName = "Stark",
            };

            Console.WriteLine(person.FirstName); // Tony
            //person.FirstName = "Howard";
            person.LastName = "Bennet";
            Console.WriteLine(person.FirstName); // Howard

        }
    }
}
