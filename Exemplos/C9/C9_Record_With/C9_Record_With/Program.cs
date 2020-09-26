using System;
using System.Text;

namespace C9_Record_With
{
    public record Person
    {
        public string LastName { get; init; }
        public string FirstName { get; init; }

        public void TakeNotes() => Console.WriteLine("It's note taking time");

        public Person(string first, string last) => (FirstName, LastName) = (first, last);

    }

    public record Teacher : Person
    {
        public string Subject { get; init; }
        public decimal Price { get; init; }

        public void Teachclass() => Console.WriteLine("It's class teaching time");

        public Teacher(string first, string last, string sub, decimal price)
            : base(first, last) => (Subject, Price) = (sub, price);
    }


    public class Friend
    {
        public string FirstName { get; init; }
        public string MiddleName { get; init; }
        public string LastName { get; init; }
    }


class Program
    {
        static void Main(string[] args)
        {
            var friend = new Friend
            {
                FirstName = "Thomas",
                MiddleName = "Claudius",
                LastName = "Huber"
            };

            var newFriend = new Friend
            {
                FirstName = friend.FirstName,
                MiddleName = friend.MiddleName,
                LastName = "Mueller"
            };


            Person person2 = new Teacher("Bill", "Wagner", "Math", 11.99m);

            var newperson2 = person2 with { LastName = "VideoGame" };

            Console.WriteLine("Type: " + newperson2.GetType().Name); //Type: Teacher
            Console.WriteLine("FirstName: " + newperson2.FirstName); //FirstName: Bill
            Console.WriteLine("LastName: " + newperson2.LastName); //LastName: VideoGame
                                                                   //Console.WriteLine("Subject: " + newperson2.Subject);
                                                                   //Console.WriteLine("Price: " + newperson2.Price);

            var teacher2 = (Teacher)newperson2; //available after casting

            Console.WriteLine("Type: " + teacher2.GetType().Name); //Type: Teacher
            Console.WriteLine("FirstName: " + teacher2.FirstName); //FirstName: Bill
            Console.WriteLine("LastName: " + teacher2.LastName); //LastName: VideoGame
            Console.WriteLine("Subject: " + teacher2.Subject);  //Subject: Math
            Console.WriteLine("Price: " + teacher2.Price);  //Price: 11,99

            Console.ReadKey();
        }
    }
}
