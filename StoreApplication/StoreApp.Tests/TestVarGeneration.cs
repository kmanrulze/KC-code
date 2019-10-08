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
            lastName = "Jane",
            customerID = "1028974"
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
        public static Product testProduct = new Product()
        {
            burgerAmount = 1,
            friesAmount = 2,
            sodaAmount = 3
        };
        public static Order testOrder = new Order()
        {
            customer = testCustomer,
            customerProductList = testProduct,
            ordererAddress = testAddress,
            orderTime = 60,
            storeLocation = testLocation,
            orderID = "12335"
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
        public Product GetProduct()
        {
            return testProduct;
        }
    }
}
