using System;
using System.Collections.Generic;
using System.Text;
using StoreApplication;

namespace StoreApp.Tests
{
    class TestVarGeneration
    {
        public static Address testAddress = new Address()
        {
            street = "777 South St",
            city = "Kersey",
            state = "CO",
            zip = "73737"
        };
        public static Customer testCustomer = new Customer()
        {
            customerAddress = testAddress,
            firstName = "Mary",
            lastName = "Jane"
        };
        public static Inventory testInventory = new Inventory()
        {
            productData = new Product()
            {
                burgerAmount = 3,
                friesAmount = 2,
                sodaAmount = 1
            }
        };
        public static Location testLocation = new Location()
        {
            address = testAddress,
            storeInventory = testInventory,
            storeNumber = "00693"
        };
        public static Order testOrder = new Order()
        {
            customer = testCustomer,
            customerProductList = new Product()
            {
                burgerAmount = 1,
                friesAmount = 1,
                sodaAmount = 1
            },
            ordererAddress = testAddress,
            orderTime = 60,
            storeLocation = testLocation
        };

        public Address GetAddress()
        {
            return testAddress;
        }
        public Customer GetCustomer()
        {
            return testCustomer;
        }
        public Inventory GetInventory()
        {
            return testInventory;
        }
        public Location GetLocation()
        {
            return testLocation;
        }
        public Order GetOrder()
        {
            return testOrder;
        }
    }
}
