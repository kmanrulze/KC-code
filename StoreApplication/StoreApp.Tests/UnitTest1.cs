using NUnit.Framework.Internal;
using StoreApplication;
using System;
using Xunit;

namespace StoreApp.Tests
{
    public class UnitTest1
    {  
        public static Address testDefaultAddress = new Address()
        {
            street = "777 South St",
            city = "Kersey",
            state = "CO",
            zip = "73737"
        };
        public Location testLocation = new Location();
        public Inventory testInventory = new Inventory();
        public Order testOrder = new Order();
        public Customer testCustomer = new Customer();

        //Tests for any null things within an address object. Returns true if all values are within it correctly and not null
        [Theory]
        [InlineData ("Arlington", "TX", "100 ABC Street", "12345")]
        [InlineData ("Denver", "CO", "777 Lucky Street", "77777")]
        public void CheckAddressReturnsTrue(string city, string state, string street, string zip)
        {
            Address testAddress = new Address();
            testAddress.city = city;
            testAddress.state = state;
            testAddress.street = street;
            testAddress.zip = zip;

            Assert.True(testAddress.CheckAddress() == true);
        }

        //Tests if something is null within the address object. Function in Address.cs returns false if any null items.
        [Theory]
        [InlineData("Arlington", "TX", "100 ABC Street", null)]
        [InlineData("Arlington", "TX", null, "12345")]
        [InlineData("Arlington", null, "100 ABC Street", "12345")]
        [InlineData(null, "TX", "100 ABC Street", "12345")]
        public void CheckAddressReturnsFalse(string city, string state, string street, string zip)
        {
            Address testAddress = new Address();
            testAddress.city = city;
            testAddress.state = state;
            testAddress.street = street;
            testAddress.zip = zip;

            Assert.False(testAddress.CheckAddress() == false);
        }

        //Tests if any customer data is firstly null, then if any of their address items are null. Passes if everything is in correctly
        [Theory]
        [InlineData("Mary", "Jane", null)]
        public void CheckCustomerDataReturnTrue(string firstName, string lastName, Address address)
        {
            address = testDefaultAddress;
            Customer newCust = new Customer();
            newCust.firstName = firstName;
            newCust.lastName = lastName;
            newCust.customerAddress = address;

            Assert.True(newCust.customerAddress.CheckAddress() == true);
            Assert.True(newCust.CheckCust() == true);
        }

        //Tests if any customer data is firstly null, then if any of their address items are null. Passes if it recognizes a null value
        [Theory]
        [InlineData("Mary", "Jane", null)]
        [InlineData("Lary", "Jane", null)]
        [InlineData("Gary", "Jane", null)]
        public void CheckCustomerDataReturnFalse(string firstName, string lastName, Address address)
        {
            //False for having a null address, or missing name anywhere
            Customer newCust = new Customer();
            newCust.firstName = firstName;
            newCust.lastName = lastName;
            newCust.customerAddress = address;

            Assert.False(newCust.customerAddress.CheckAddress() == true);
            Assert.False(newCust.CheckCust() == true);
        }
        
        //Tests if items were properly added to the list of products, then sets it to the inventory. Checks to make sure the inventory properly accepted the list of product.
        [Theory]
        [InlineData(null, null, null)]
        public void CreateTestProductListAndInventory(int burgers, int fries, int soda)
        {
            Product testProductList = new Product(); 
            testProductList.burgerAmount = burgers;
            testProductList.friesAmount = fries;
            testProductList.sodaAmount = soda;

            testInventory.inventoryData = testProductList;

            Assert.True(testInventory.inventoryData.CheckInventoryNotNull() == true);
        }
 /*       [Fact]
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
        }*/
    }
}
