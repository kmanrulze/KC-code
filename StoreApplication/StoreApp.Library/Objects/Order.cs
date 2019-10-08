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
        public string orderID { get; set; }

        public void CheckOrderIsValid()
        {
            //some code to check if order isnt ridiculous
        }
        public bool CheckOrderNotNull()
        {
            if (this.storeLocation.CheckLocationNotNull() == true &&
                this.ordererAddress.CheckAddressNotNull() ==  true &&
                this.customer.CheckCustomerNotNull() == true &&
                this.customerProductList.CheckProductNotNull() == true && orderTime != 0 && orderID != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckOrdererAddress()
        {
            if (this.ordererAddress.CheckAddressNotNull() == true)
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
