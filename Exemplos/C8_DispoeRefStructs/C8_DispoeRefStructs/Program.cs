using System;

namespace C8_DispoeRefStructs
{
    class Program
    {
        static void Main(string[] args)
        {
            //var book1 = new Book() { Texto = "Hello World!" };
            //Console.WriteLine(book1.Texto);
            //book1.Dispose();

            using (var book = new Book() { Texto = "Hello World!" })
                Console.WriteLine(book.Texto);
        }
    }

    ref struct Book
    {
        public string Texto { get; set; }
        public void Dispose()
        {
        }
    }
}
