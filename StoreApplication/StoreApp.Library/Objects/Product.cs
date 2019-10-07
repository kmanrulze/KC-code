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

        public bool CheckInventoryNotNull()
        {
            bool checkBool = true;
            if(this.burgerAmount != null && this.friesAmount != null && this.sodaAmount != null)
            {
                return checkBool;
            }
            else
            {
                checkBool = false;
                return checkBool;
            }
        }
    }
}
