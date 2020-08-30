using System;

namespace C8_InterfacePadrao
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31))
            {
                Reminders =
                {
                    { new DateTime(2010, 08, 12), "childs's birthday" },
                    { new DateTime(1012, 11, 15), "anniversary" }
                }
            };

            ICustomer theCustomer = c;

            Console.WriteLine($"Discount Version 3: {theCustomer.ComputeLoyaltyDiscount()}"); // 0,50

            SampleOrder o = new SampleOrder(new DateTime(2012, 6, 1), 5m);
            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2103, 7, 4), 25m);
            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2104, 3, 2), 15m);
            c.AddOrder(o);

            // Check the discount:

            Console.WriteLine($"Discount Version  1: {theCustomer.ComputeLoyaltyDiscount()}"); // 0,10

            ICustomer.SetLoyaltyThresholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
            Console.WriteLine($"Discount Version  2: {theCustomer.ComputeLoyaltyDiscount()}"); // 0,25
        }
    }
}
