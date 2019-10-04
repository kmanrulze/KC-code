using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    class Location
    {
        public Inventory inventory { get; set; }
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
