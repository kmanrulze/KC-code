using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BusinessLogic.Objects
{
    public class Order
    {
        public Store storeLocation = new Store();
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
                this.customerProductList.CheckProductCountNotInvalid() == true && orderTime >= 0 && this.orderID > 0)
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

        public void CalculateOrderTime(Product customerProductList)
        {
            //Business rule for adding how to calculate the order time

            this.orderTime = 5;
        }
    }
}
