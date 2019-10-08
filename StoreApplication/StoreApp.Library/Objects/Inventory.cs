using System.Collections.Generic;

namespace StoreApplication
{
    public class Inventory
    {

        public Product productData { get; set; }

        public void RestockShelves(List<Product> incomingStock)
        {
            //some code to add to the amount of stuff in the shelves of the store
        }
        public void CheckIfNoProduct()
        {
            //checks amounts to ensure if the list of products are 0 or not
        }
        public void ReturnStockAmounts()
        {
            //returns stock amounts for the current inventory
        }
        public bool CheckInventoryNotNull()
        {
            if (productData.CheckProductCountNotInvalid() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}