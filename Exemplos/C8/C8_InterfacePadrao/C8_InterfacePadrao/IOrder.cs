using System;
using System.Collections.Generic;
using System.Text;

namespace C8_InterfacePadrao
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }

    }
}
