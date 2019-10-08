using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    public class Product
    {
        public string burger = "Hamburger";
        public int burgerAmount { get; set; }
        public string fries = "Fries";
        public int friesAmount { get; set; }
        public string soda = "Soda";
        public int sodaAmount { get; set; }

        public bool CheckProductNotNull()
        {
            bool checkBool = true;
            if(this.burgerAmount >= 0 && this.friesAmount >= 0 && this.sodaAmount >= 0)
            {
                return checkBool;
            }
            else
            {
                checkBool = false;
                return checkBool;
            }
        }

        public bool CheckInventoryNotNull()
        {
            throw new NotImplementedException();
        }
    }
}
