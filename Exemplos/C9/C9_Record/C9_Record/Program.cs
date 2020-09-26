using System;
using System.Text;

namespace C9_Record
{
    public record Person
    {
        string LastName { get; }
        string FirstName { get; }

        public void TakeNotes() => Console.WriteLine("It's note taking time");

        public Person(string first, string last) => (FirstName, LastName) = (first, last);

    }

    public record Teacher : Person
    {
        public string Subject { get; }
        public decimal Price { get; }

        public void Teachclass() => Console.WriteLine("It's class teaching time");

        public Teacher(string first, string last, string sub, decimal price)
            : base(first, last) => (Subject, Price) = (sub, price);
    }

    public sealed record Student : Person
    {
        public int Level { get; }

        public Student(string first, string last, int level)
            : base(first, last) => Level = level;
    }


    public record Person2(string FirstName, string LastName);

    public record Teacher2(string FirstName, string LastName, string Subject, decimal Price) : Person2(FirstName, LastName);

    public sealed record Student2(string FirstName, string LastName, int Level) : Person2(FirstName, LastName);


    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Bill", "Wagner");
            var student = new Student("Bill", "Wagner", 11);

            Console.WriteLine(student.GetHashCode()); // -2031643194
            Console.WriteLine(person.GetHashCode()); // 327587142
            Console.WriteLine(student == person); // false

            var teacher = new Teacher("Bill", "Wagner", "Math", 11.99m);
            Console.WriteLine(person.ToString()); // C9_Record.Person
            Console.WriteLine(teacher.ToString()); // C9_Record.Teacher





            var person2 = new Person2("Bill", "Wagner");
            var student2 = new Student2("Bill", "Wagner", 11);

            Console.WriteLine(student2.GetHashCode()); // -2031643194
            Console.WriteLine(person2.GetHashCode()); // 327587142
            Console.WriteLine(student2 == person2); // false

            var teacher2 = new Teacher2("Bill", "Wagner", "Math", 11.99m);
            Console.WriteLine(person2.ToString()); // C9_Record.Person
            Console.WriteLine(teacher2.ToString()); // C9_Record.Teacher2

            Console.ReadKey();
        }
    }
}
