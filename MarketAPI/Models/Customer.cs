using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Models
{
    public static class Customer
    {
        static Customer()
        {
            MyBagItems = new List<Item>();
            Money = 500000;
        }
        public static List<Item> MyBagItems;
        public static double Money;
    }
}
