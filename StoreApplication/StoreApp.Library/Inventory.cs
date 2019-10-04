using System.Collections.Generic;

namespace StoreApplication
{
    public class Inventory
    {
        public List<Product> inventoryData { get; set; } = new List<Product>();

        public void RestockShelves(List<Product> incomingStock)
        {
            //some code to add to the amount of stuff in the shelves of the store
        }

    }
}