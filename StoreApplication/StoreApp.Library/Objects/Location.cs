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
        public bool CheckInventory(Location locationBeingChecked, Order order)
        {
            //If the ordered amount doesnt exceed any of the three things the store has
            if (locationBeingChecked.storeInventory.inventoryData.burgerAmount >= order.customerProductList.burgerAmount && 
                locationBeingChecked.storeInventory.inventoryData.friesAmount >= order.customerProductList.friesAmount &&
                locationBeingChecked.storeInventory.inventoryData.sodaAmount >= order.customerProductList.sodaAmount)
            {
                //Order is successful
                Console.WriteLine("Location has sufficient product.");

                UpdateInventory(locationBeingChecked, order);

                return true;
            }
            else
            {

                Console.WriteLine("Location does not have all the necessary things needed for the order. Location contains " +
                    locationBeingChecked.storeInventory.inventoryData.burgerAmount.ToString() + " burgers, " + 
                    locationBeingChecked.storeInventory.inventoryData.friesAmount.ToString() +  " fries, and " +
                    locationBeingChecked.storeInventory.inventoryData.sodaAmount.ToString());

                Console.WriteLine("Client order is requesting " +
                    order.customerProductList.burgerAmount + " burgers, " +
                    order.customerProductList.friesAmount.ToString() + " fries, and " +
                    order.customerProductList.sodaAmount.ToString());

                return false;
            }
        }
        public void UpdateInventory(Location locationToBeUpdated, Order placedOrder)
        {
            locationToBeUpdated.storeInventory.inventoryData.burgerAmount = locationToBeUpdated.storeInventory.inventoryData.burgerAmount - placedOrder.customerProductList.burgerAmount;
            locationToBeUpdated.storeInventory.inventoryData.friesAmount = locationToBeUpdated.storeInventory.inventoryData.friesAmount - placedOrder.customerProductList.friesAmount;
            locationToBeUpdated.storeInventory.inventoryData.sodaAmount = locationToBeUpdated.storeInventory.inventoryData.sodaAmount - placedOrder.customerProductList.sodaAmount;

            Console.WriteLine("Updated location for store number " + locationToBeUpdated.storeNumber.ToString() + ".\n");
            Console.WriteLine("Store inventory contains " +
                    locationToBeUpdated.storeInventory.inventoryData.burgerAmount.ToString() + " burgers, " +
                    locationToBeUpdated.storeInventory.inventoryData.friesAmount.ToString() + " fries, and " +
                    locationToBeUpdated.storeInventory.inventoryData.sodaAmount.ToString());

            return;
        }


    }
}
