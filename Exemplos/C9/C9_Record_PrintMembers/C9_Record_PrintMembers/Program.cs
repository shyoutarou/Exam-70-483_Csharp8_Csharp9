using System;
using System.Text;

namespace C9_Record_PrintMembers
{
    public record Person
    {
        string LastName { get; }
        string FirstName { get; }

        public void TakeNotes() => Console.WriteLine("It's note taking time");

        public Person(string first, string last) => (FirstName, LastName) = (first, last);

        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append("FirstName");
            builder.Append(" = ");
            builder.Append((object)FirstName);
            builder.Append(", ");
            builder.Append("LastName");
            builder.Append(" = ");
            builder.Append((object)LastName);
            return true;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(nameof(Person));
            builder.Append(" { ");

            if (PrintMembers(builder))
                builder.Append(" ");

            builder.Append("}");
            return builder.ToString();
        }
    }

    public record Teacher : Person
    {
        public string Subject { get; }
        public decimal Price { get; }

        public void Teachclass() => Console.WriteLine("It's class teaching time");

        protected override bool PrintMembers(StringBuilder builder)
        {
            if (base.PrintMembers(builder))
                builder.Append(", ");

            builder.Append(nameof(Subject));
            builder.Append(" = ");
            builder.Append(this.Subject); // or builder.Append(this.P2); if P2 has a value type

            builder.Append(", ");

            builder.Append(nameof(Price));
            builder.Append(" = ");
            builder.Append(this.Price); // or builder.Append(this.P3); if P3 has a value type

            return true;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(nameof(Teacher));
            builder.Append(" { ");

            if (PrintMembers(builder))
                builder.Append(" ");

            builder.Append("}");
            return $"{builder.ToString()} is a Class";
        }

        public Teacher(string first, string last, string sub, decimal price)
            : base(first, last) => (Subject, Price) = (sub, price);
    }

    public sealed record Student : Person
    {
        public int Level { get; }

        protected override bool PrintMembers(StringBuilder builder)
        {
            if (base.PrintMembers(builder))
                builder.Append(", ");

            builder.Append(nameof(Level));
            builder.Append(" = ");
            builder.Append(this.Level);

            return true;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(nameof(Student));
            builder.Append(" { ");

            if (PrintMembers(builder))
                builder.Append(" ");

            builder.Append("}");
            return $"{builder.ToString()}";
        }

        public Student(string first, string last, int level)
            : base(first, last) => Level = level;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Bill", "Wagner");
            var student = new Student("Jean", "Woo", 11);

            //Person { FirstName = Bill, LastName = Wagner }
            Console.WriteLine(person.ToString());

            //Student { FirstName = Jean, LastName = Woo, Level = 11 }
            Console.WriteLine(student.ToString());

            var teacher = new Teacher("Mike", "Todd", "Math", 11.99m);
            //Teacher { FirstName = Mike, LastName = Todd, Subject = Math, Price = 11,99 } is a Class
            Console.WriteLine(teacher.ToString());

        }
    }
}
