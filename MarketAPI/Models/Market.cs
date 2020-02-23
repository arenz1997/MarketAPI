using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Models
{
    public static class Market
    {
        static Market()
        {
            Items = new List<Item>();
            Items.Add(new Item { description = "iPhone X", price = 500000, addedDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() });
            Items.Add(new Item { description = "Notebook", price = 700000, addedDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() });
            Items.Add(new Item { description = "TV", price = 200000, addedDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() });
            
            Employeers = new List<Employeer>();
            Employeers.Add(new Employeer { name = "Poghos", surname = "Petrosyan", salary = 170000 });
            Employeers.Add(new Employeer { name = "Petros", surname = "Poghosyan", salary = 150000 });

            Income = 0;
        }
        public static List<Item> Items;
        public static List<Employeer> Employeers;
        public static double Income;
    }
}
