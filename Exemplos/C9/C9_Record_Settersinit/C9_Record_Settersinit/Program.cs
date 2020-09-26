using System;
using System.Text;

namespace C9_Record_Settersinit
{

    public class Person0
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Person
    {
        private readonly string lastName;
        public string FirstName { get; init; }
        public string LastName
        {
            get => lastName;
            init => lastName = (value ?? throw new ArgumentNullException(nameof(LastName)));
        }
    }


    public struct WeatherObservation
    {
        public DateTime RecordedAt { get; init; }
        public decimal TemperatureInCelsius { get; init; }
        public decimal PressureInMillibars { get; init; }


        public void ForecastFor(DateTime forecastDate, string options) => Console.WriteLine("It's class teaching time" + options);


        public override string ToString() =>
            $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
            $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var now = new WeatherObservation
            {
                RecordedAt = DateTime.Now,
                TemperatureInCelsius = 20,
                PressureInMillibars = 998.0m
            };

            //At 4:37 PM on 9/23/2020: Temp = 20, with 998,0 pressure
            Console.WriteLine(now.ToString());

            var person = new Person0
            {
                FirstName = "Scott",
                LastName = "Hunter"
            };


            Console.ReadKey();
        }
    }
}
