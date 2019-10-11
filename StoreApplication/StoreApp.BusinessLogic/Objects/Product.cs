using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BusinessLogic.Objects
{
    public class Product
    {
        public string burger = "Hamburger";
        public int burgerAmount = 0;
        public string fries = "Fries";
        public int friesAmount = 0;
        public string soda = "Soda";
        public int sodaAmount = 0;

        public bool CheckProductCountNotInvalid()
        {
            if(this.burgerAmount >= 0 && this.friesAmount >= 0 && this.sodaAmount >= 0)
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
