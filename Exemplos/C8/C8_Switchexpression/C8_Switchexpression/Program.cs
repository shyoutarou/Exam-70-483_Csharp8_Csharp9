using System;
using System.ComponentModel.DataAnnotations;

namespace C8_Switchexpression
{
    // Expressão Switch
    public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    // Pattern posicionais
    public enum Quadrant
    {
        Unknown,
        Origin,
        One,
        Two,
        Three,
        Four,
        OnBorder
    }

    // Expressão Switch
    public class RGBColor
    {
        public String ColorHex;
        public RGBColor(byte R, byte G, byte B)
        {
            var color = System.Drawing.Color.FromArgb(R, G, B);
            ColorHex = color.Name;
        }
    }

    //Pattern de propriedade
    public class Address
    {
        public string State { get; set; }
    }

    //Pattern posicionais
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y) =>
            (x, y) = (X, Y);
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Expressão Switch
            var cor = FromRainbow(Rainbow.Yellow);
            Console.WriteLine("HEX:" + cor.ColorHex);

            //Pattern de propriedade
            var preco = ComputeSalesTax(new Address() { State = "MN" }, 3);
            Console.WriteLine("Preço:" + preco);

            //Pattern de tupla
            var jankenpo = RockPaperScissors("paper", "scissors");
            Console.WriteLine("Resultado:" + jankenpo);

            // Pattern posicionais
            var posicao = GetQuadrant(new Point(10, 2));
            Console.WriteLine("Posição:" + posicao);

            Console.ReadKey();
        }

        // Expressão Switch
        public static RGBColor FromRainbow(Rainbow colorBand) =>
            colorBand switch
            {
                Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
                Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
                Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
                Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
                Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
                Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
                Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
            };

        //Pattern de propriedade
        public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
                location switch
                {
                    { State: "WA" } => salePrice * 0.06M,
                    { State: "MN" } => salePrice * 0.075M,
                    { State: "MI" } => salePrice * 0.05M,
                    // other cases removed for brevity...
                    _ => 0M
                };

        //Pattern de tupla
        public static string RockPaperScissors(string first, string second)
            => (first, second) switch
            {
                ("rock", "paper") => "rock is covered by paper. Paper wins.",
                ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                ("paper", "rock") => "paper covers rock. Paper wins.",
                ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                (_, _) => "tie"
            };

        static Quadrant GetQuadrant(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };


    }
}
