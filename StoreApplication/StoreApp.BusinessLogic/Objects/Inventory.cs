using System;
using System.Collections.Generic;


namespace StoreApp.BusinessLogic.Objects
{
    public class Inventory
    {

        public List<Product> productData = new List<Product>();

        public void RestockShelves(List<Product> incomingStock)
        {
            //some code to add to the amount of stuff in the shelves of the store
        }
        public void ReturnStockAmounts()
        {
            //returns stock amounts for the current inventory
        }

        public bool CheckIfProductListNotNull()
        {
            if (productData.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}