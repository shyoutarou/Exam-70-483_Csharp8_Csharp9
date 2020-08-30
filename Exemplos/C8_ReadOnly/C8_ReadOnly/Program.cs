using System;

namespace C8_ReadOnly
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        public readonly override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";

        public readonly void Translate(int xOffset, int yOffset)
        {
            X += xOffset;
            Y += yOffset;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ponto = new Point();
            ponto.X = 10;
            ponto.Y = 20;
            Console.WriteLine(ponto.ToString());
            //(10, 20) is 22,360679774997898 from the origin

            ponto.Translate(2, 8);
            Console.WriteLine(ponto.ToString());
            //(12, 28) is 30,463092423455635 from the origin
        }
    }
}
