using System;

namespace C9_TargetTyped_Cond
{
    public class Person
    {
        private string _firstName;
        private string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }

    public class Student : Person
    {
        private string _nickname;
        private int _level;
        
        public Student(string firstName, string lastName, string nickname, int level) : base(firstName, lastName)
        {
            _level = level;
            _nickname = nickname;
        }
    }

    public class Teacher : Person
    {
        private string _subject;
        private int _price;

        public Teacher(string firstName, string lastName, string subject, int price) : base(firstName, lastName)
        {
            _subject = subject;
            _price = price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Roy", "Nelson", "Roro", 42);
            Teacher teacher = new Teacher("Tony", "Bob", "Math", 100);

            //Em 24/09/2020 ainda não funcionava
            //Person anotherPerson = student ?? teacher;

            Console.WriteLine("Hello World!");
        }
    }
}
