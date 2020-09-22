using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace C8_NullReference
{
    public class Car
    {
        public string Brand { get; set; } = null!;
        public string Make { get; set; }

        [Required]
        public string LastName { get; set; } = null!;

        void MetodoTeste(string? nome)
        {
            Console.WriteLine(nome!.Length);       // Warning: Possível exceção e referência nula
            if (nome != null)
            {
                Console.WriteLine(nome.Length);    // Ok: Se nome for null esse código não executa
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
#nullable enable
            string cantBeNull = null; /*Warning: Assignment of null to non-nullable reference type*/
            string? canBeNull = null; /*OK*/
            cantBeNull = canBeNull; // Aviso
#nullable restore

            Console.WriteLine("Hello World!");
        }
    }
}
