using System;
using System.Collections.Generic;

namespace StoreApp.DataLibrary.Entities
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreNumber { get; set; }
        public int BurgerAmount { get; set; }
        public int FriesAmount { get; set; }
        public int SodaAmount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store StoreNumberNavigation { get; set; }
    }
}
