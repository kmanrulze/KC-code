
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    public class Customer
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address customerAddress { get; set; }
        public string customerID { get; set; }

        public bool CheckCustomerNotNull()
        {

            if (this.customerAddress.CheckAddressNotNull() == true && this.firstName != null && this.lastName != null && this.customerID != null)
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
