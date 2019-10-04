using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    class Order
    {

        public Address address { get; set; }
        public Customer customer { get; set; }
        public double orderTime { get; set; }

        public void CheckOrderRules(Order placedOrder)
        {
            //Additional business rules
        }
        public void CheckOrderIsValid(Order placedOrder)
        {
            //some code to check if order isnt ridiculous
        }
    }
}
