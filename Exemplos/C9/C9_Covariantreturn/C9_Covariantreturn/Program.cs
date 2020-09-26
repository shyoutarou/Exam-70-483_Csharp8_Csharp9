using System;

namespace C9_Covariantreturn
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

        public virtual Person GetPerson()
        {
            return new Person(_firstName, _lastName);
        }
    }

    public class Student : Person
    {
        private string _favoriteSubject;
        private string _firstName;
        private string _lastName;

        public Student(string firstName, string lastName, string favoriteSubject) : base(firstName, lastName)
        {
            _favoriteSubject = favoriteSubject;
            _firstName = firstName;
            _lastName = lastName;
        }

        //public override Person GetPerson()
        //{
        //    // you can return the child class, but still return a Person
        //    return new Student(_firstName, _lastName, "None");
        //}

        // Não funcionando em 24/09/2020
        //public override Student GetPerson()
        //{
        //    // you can return the child class, but still return a Person
        //    return new Student(_firstName, _lastName, "None");
        //}
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
