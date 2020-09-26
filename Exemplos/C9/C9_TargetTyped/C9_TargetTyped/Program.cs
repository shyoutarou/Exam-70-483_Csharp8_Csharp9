using System;
using System.Collections.Generic;

namespace C9_TargetTyped
{
    public class Person
    {
        //....
        private string _firstName;
        private string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public void Encontro(DateTime dia, Opcoes options) => Console.WriteLine("It's class teaching time: " + dia.ToString() + "-" + options.texto);
    }

    public class Opcoes
    {
        private int _num;
        private string _txt;

        public Opcoes() { }
        public Opcoes(int numero, string texto)
        {
            _num = numero;
            _txt = texto;
        }
        public int numero { get { return _num; } set { _num = value; } }
        public string texto { get { return _txt; } set { _txt = value; } }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person person = new("Bob", "Dyla");
            List<Person> _observations = new();

            var personList = new List<Person>
            {
                new ("Bob", "Marei"),
                new ("Bob", "Quened"),
                new ("Uncle", "Bob"),
                new ("Rick", "Bob")
            };

            person.Encontro(DateTime.Now.AddDays(2), new(1, "oi"));


            Opcoes opcoes = new() { numero = 42, texto = "Seattle, WA" };
            var now = new Opcoes
            {
                numero = 20,
                texto = DateTime.Now.ToString()
            };

            Console.WriteLine("Hello World!");
        }
    }
}
