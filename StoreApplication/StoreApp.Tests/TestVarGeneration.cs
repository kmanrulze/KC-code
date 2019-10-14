using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BusinessLogic.Objects;

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
            customerID = 6
        };
        public static Inventory testInventory = new Inventory()
        {
            productData = new List<Product>()
        };
        public static Store testLocation = new Store()
        {
            address = testAddress,
            storeInventory = testInventory,
            storeNumber = 6
        };
        public static Product testProduct = new Product()
        {
            productTypeID = 1,
            name = "Burgers",
            amount = 1
        };
        public static Order testOrder = new Order()
        {

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
        public Store GetLocation()
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
