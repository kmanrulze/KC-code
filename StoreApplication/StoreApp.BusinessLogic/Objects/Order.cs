using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    public class Order
    {
        public Location storeLocation = new Location();
        public Address ordererAddress = new Address();
        public Customer customer = new Customer();
        public Product customerProductList = new Product();
        public double orderTime { get; set; }
        public int orderID { get; set; }

        public void CheckOrderIsValid()
        {
            //some code to check if order isnt ridiculous
        }
        public bool CheckOrderNotNull()
        {
            if (this.storeLocation.CheckLocationNotNull() == true &&
                this.ordererAddress.CheckAddressNotNull() ==  true &&
                this.customer.CheckCustomerNotNull() == true &&
                this.customerProductList.CheckProductCountNotInvalid() == true && orderTime >= 0 && this.orderID != null)
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
