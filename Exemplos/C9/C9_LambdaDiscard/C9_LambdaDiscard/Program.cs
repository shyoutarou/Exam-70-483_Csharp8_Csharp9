using System;

namespace C9_LambdaDiscard
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> subtrai_func = SubtraiNumbers;



            //Func<int, int, int> zero = (_, _) => 0;

            //(_, _) => 1, (int _, string _) => 1, void local(int _, int _);



            //Func<int> zero = (_, _) => 0, (int _, int _) => 0;

            //Func zero = (_, _) => 0;
            //(_, _) => 1, (int, string) => 1, void local(int , int);



            //button1.Click += (s, e) => ShowDialog();
            //button1.Click + = (_, _) => ShowDialog();
            //var handler = (object _, EventArgs _) => ShowDialog();


            Console.WriteLine("Hello World!");
        }

        public static int SubtraiNumbers(int a, int b)
        {
            var subtrai = a - b;
            return subtrai;
        }
    }
}
