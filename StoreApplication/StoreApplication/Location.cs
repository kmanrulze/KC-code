using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication
{
    class Location
    {
        public Address address { get; set; }
        public Customer customer { get; set; }
        public double orderTime { get; set; }

    }
}
