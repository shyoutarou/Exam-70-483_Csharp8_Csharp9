using System;

namespace C9_PatternMatch
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public bool IsChild() => Age is >= 10 and <= 18;
        public bool TakeNotes(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
        public bool TakeNotesOrSeparator(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
    }

    class Program
    {
        static void Main(string[] args)
        {
            void TypePattern(object tipo1, object tipo2)
            {
                var t = (tipo1, tipo2);
                if (t is (int, string))
                {
                    Console.WriteLine("É inteiro ou string!");
                }

                switch (tipo1)
                {
                    case int:
                        Console.WriteLine("É inteiro!");
                        break;
                    case System.String:
                        Console.WriteLine("É string!");
                        break;
                }
            }

            int numero = 1;
            string texto = "texto";
            TypePattern(numero, texto);

            Console.WriteLine("Hello World!");
        }

        public static string Exemplo_C8(string languageInput)
        {
            string languagePhrase = languageInput switch
            {
                "C#" => "C# is fun!",
                "JavaScript" => "JavaScript is mostly fun!",
                _ => throw new Exception("You code in something else I don't recognize."),
            };
            return languagePhrase;
        }

        public static string Exemplo_C9(string languageInput)
        {
            var person = new Person
            {
                FirstName = "Tony",
                LastName = "Ramos",
                Age = 45
            };

            string Switch_C8(object pessoa) => pessoa switch
            {
                Person s when s.Age < 10 => "Criança",
                Person s when s.Age <= 40 => "Adulto",
                Person _ => "Senior",
                _ => throw new ArgumentException("I do not know this one", nameof(pessoa))
            };

            Console.WriteLine(Switch_C8(person)); //"Senior"


            static string SwitchTipoSimples_C9(object simply) => simply switch
            {
                Person s when s.Age < 10 => "Criança",
                Person s when s.Age <= 40 => "Adulto",
                Person => "Senior",
                not null => throw new ArgumentException($"I do not know this one: {simply}", nameof(simply)),
                null => throw new ArgumentNullException(nameof(simply))
            };

            static string SwitchRelacional_C9(Person hero) => hero.Age switch
            {
                < 10 => "Criança",
                <= 40 => "Adulto",
                _ => "Senior"
            };

            static string SwitchLogico_C9(Person hero) => hero.Age switch
            {
                1 or 2 => "Bebê",
                < 10 and < 18 => "Criança",
                <= 40 => "Adulto",
                _ => "Senior"
            };

            if (!(person is Person)) { }

            if (person is not Person) { }


            return SwitchRelacional_C9(person);  // "Senior"
        }

    }
}
