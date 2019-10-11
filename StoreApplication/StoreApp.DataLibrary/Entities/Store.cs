using System;
using System.Collections.Generic;

namespace StoreApp.DataLibrary.Entities
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Orders>();
        }

        public int StoreNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int BurgerAmount { get; set; }
        public int FriesAmount { get; set; }
        public int SodaAmount { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
