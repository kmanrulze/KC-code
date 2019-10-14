using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BusinessLogic.Objects
{
    public class Order
    {
        public Store storeLocation = new Store();
        public Customer customer = new Customer();
        public List<Product> customerProductList = new List<Product>();
        public double orderTime { get; set; }
        public int orderID { get; set; }

        public void CheckOrderIsValid()
        {
            //some code to check if order isnt ridiculous
        }
        public bool CheckOrderNotNull()
        {
            if (this.storeLocation.CheckLocationNotNull() == true &&
                this.customer.CheckCustomerNotNull() == true &&
                orderTime >= 0 && this.orderID > 0)
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
