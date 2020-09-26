using System;
using System.Collections.Generic;
using System.Text;

namespace C8_InterfacePadrao
{
public class SampleOrder : IOrder
{
    public SampleOrder(DateTime purchase, decimal cost) =>
        (Purchased, Cost) = (purchase, cost);

    public DateTime Purchased { get; }

    public decimal Cost { get; }
}
}
