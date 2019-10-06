using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    public class Order
    {
        public Location storeLocation { get; set; }
        public Address ordererAddress { get; set; }
        public Customer customer { get; set; }
        public Product customerProductList { get; set; }
        public double orderTime { get; set; }

        public void CheckOrdererAddress(Order placedOrder)
        {
            //checks orderer's address is valid
        }
        public void CheckOrderIsValid(Order placedOrder)
        {
            //some code to check if order isnt ridiculous
        }
    }
}
