using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C8_InterfacePadrao
{
    public interface ICustomer
    {
        public  IEnumerable<IOrder> PreviousOrders { get; }
        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }

        // Version 1: HARD CODE
        //public decimal ComputeLoyaltyDiscount()
        //{
        //    DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
        //    if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 1))
        //    {
        //        return 0.10m;
        //    }
        //    return 0;
        //}

        // Version 2: PARAMETERS !!!
        public static void SetLoyaltyThresholds(
            TimeSpan ago,
            int minimumOrders = 2,
            decimal percentageDiscount = 0.10m)
        {
            length = ago;
            orderCount = minimumOrders;
            discountPercent = percentageDiscount;
        }
        private static TimeSpan length = new TimeSpan(365 * 2, 0, 0, 0); // two years
        private static int orderCount = 2;
        private static decimal discountPercent = 0.10m;

        // Version 3: EXTENDED DEFAULT INTERFACE !!!
        public decimal ComputeLoyaltyDiscount() => DefaultLoyaltyDiscount(this);
        protected static decimal DefaultLoyaltyDiscount(ICustomer c)
        {
            DateTime start = DateTime.Now - length;

            if ((c.DateJoined < start) && (c.PreviousOrders.Count() > orderCount))
            {
                return discountPercent;
            }
            return 0;
        }
    }
}
