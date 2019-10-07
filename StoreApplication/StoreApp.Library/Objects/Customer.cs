
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

        public bool CheckCust()
        {
            bool testCheck = true;

            if (this.customerAddress != null && this.firstName != null && this.lastName != null)
            {
                return testCheck;
            }
            else
            {
                testCheck = false;
            }
            return testCheck;
        }
    }
}
