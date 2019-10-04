using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    public class Location
    {
        public Address address { get; set; }
        public Inventory storeInventory { get; set; }
        public int storeNumber { get; set; }
        public void CheckInventory(Location locationBeingChecked)
        {
            //some code to check the inventory of the location being input
        }
        public void UpdateInventory(Order placedOrder)
        {
            //some code to update inventory when order is placed
        }


    }
}
