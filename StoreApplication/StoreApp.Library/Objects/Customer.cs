
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

        public bool CheckCustomerNotNull()
        {

            if (this.customerAddress != null && this.firstName != null && this.lastName != null)
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
