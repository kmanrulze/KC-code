using StoreApplication;
using System;
using Xunit;

namespace StoreApp.Tests
{
    public class UnitTest1
    {
        public Address testOrdererAddress = new Address();
        public Address testLocationAddress = new Address();
        public Location testLocation = new Location();
        public Inventory testInventory = new Inventory();
        public Product testProductList = new Product();
        public Order testOrder = new Order();
        public Customer testCustomer = new Customer();

        [Fact]
        public void CreateTestAddresses()
        {
            testOrdererAddress.city = "Arlington";
            testOrdererAddress.state = "TX";
            testOrdererAddress.street = "100 ABC Street";
            testOrdererAddress.zip = "12345";

            testLocationAddress.city = "Austin";
            testLocationAddress.state = "TX";
            testLocationAddress.street = "123 Dab Street";
            testLocationAddress.zip = "67890";
        }
        [Fact]
        public void CreateTestCustomer()
        {
            testCustomer.firstName = "Mary";
            testCustomer.lastName = "Jane";
            testCustomer.customerAddress = testOrdererAddress;
        }
        [Fact]
        public void CreateTestProductListAndInventory()
        {
            testProductList.burgerAmount = 5;
            testProductList.friesAmount = 5;
            testProductList.sodaAmount = 5;

            testInventory.inventoryData = testProductList;
        }
        [Fact]
        public void CreateTestLocation()
        {
            testLocation.address = testLocationAddress;
            testLocation.storeInventory = testInventory;
            testLocation.storeNumber = 00693;
        }
        [Fact]
        public void CreateTestOrder()
        {
            testOrder.customer = testCustomer;
            testOrder.ordererAddress = testCustomer.customerAddress;
            testOrder.orderTime = 50;
            testOrder.storeLocation = testLocation;
        }
    }
}
