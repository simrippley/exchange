using System;
using System.Collections.Generic;
using System.Text;
using CriptoExchengLib.Interfaces;

namespace CriptoExchengLib.Classes
{
    public class BinanceOrder : IOrder
    {
        public int Id { get; set; }
        public ICurrencyPair Pair { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public IOrderType Type { get; set; }
        public IOrderType Side { get; set; }
        public double Amount { get; set; }
        public DateTime OpenTm { get; set; }
        public BaseOrderStatus Status { get; set; }

        public TimeInForce TimeInForce {get;set;}
    }

    public enum TimeInForce
    {
        GTC,
        IOC,
        FOK
    }
}
