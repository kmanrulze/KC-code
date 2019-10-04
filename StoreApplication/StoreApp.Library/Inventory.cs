using System.Collections.Generic;

namespace StoreApplication
{
    public class Inventory
    {
        //dictionary arranged by string, for what the item is, and int for how many the place has
        public IDictionary<string, int> inventory { get; set; }
    }
}