using System;

namespace C8_UnmanagedTypes
{
    public struct Coords<T>
    {
        public T X;
        public T Y;
    }

    //public struct Coords<T> where T : unmanaged
    //{
    //    public T X;
    //    public T Y;
    //}

    class Program
    {
        static void Main(string[] args)
        {
            DisplaySize<Coords<int>>();
            DisplaySize<Coords<double>>();


            //Pode alocar um bloco de memória na pilha para instâncias desse tipo:
            Span<Coords<int>> coordinates = stackalloc[]
            {
                new Coords<int> { X = 0, Y = 0 },
                new Coords<int> { X = 0, Y = 3 },
                new Coords<int> { X = 4, Y = 0 }
            };


            //Pode criar um ponteiro para uma variável desse tipo
            unsafe
            {
                int length = 3;
                Coords<int>* numbers = stackalloc Coords<int>[length];
                for (var i = 0; i < length; i++)
                {
                    numbers[i] = new Coords<int> { X = 0, Y = i };
                }
            }

            Console.ReadKey();
        }

        private unsafe static void DisplaySize<T>() where T : unmanaged
        {
            Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
        }
    }
}
