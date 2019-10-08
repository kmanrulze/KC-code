using NUnit.Framework.Internal;
using StoreApplication;
using System;
using System.Collections.Generic;
using Xunit;

namespace StoreApp.Tests
{
    public class UnitTest1
    {
        private TestVarGeneration testVariable = new TestVarGeneration();

        //---------------------------------------------------------------------------------------------------------------------------------
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

            Assert.True(testAddress.CheckAddressNotNull() == true);
        }

        //---------------------------------------------------------------------------------------------------------------------------------
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

            Assert.False(testAddress.CheckAddressNotNull() == false);
        }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests if any customer data is firstly null, then if any of their address items are null. Passes if everything is in correctly
        //Address is expected to return true. A known good address is being passed in
        [Theory]
        [InlineData("Mary", "Jane")]
        [InlineData("Gary", "Hanes")]
        public void CheckCustomerDataReturnTrue(string firstName, string lastName)
        {

            Customer newCust = new Customer();
            newCust.firstName = firstName;
            newCust.lastName = lastName;
            newCust.customerAddress = testVariable.GetAddress();

            Assert.True(newCust.customerAddress.CheckAddressNotNull() == true);
            Assert.True(newCust.CheckCustomerNotNull() == true);
        }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests if any customer data is firstly null, then if any of their address items are null.
        //Should pass on Assert True for the test address passed in that is a known correct value, and false for the false assert as expected
        [Theory]
        [InlineData("Gary", "Lanes")]
        [InlineData("Boom", "Zoom")]
        public void CheckCustomerDataReturnFalse(string firstName, string lastName)
        {
            //False for having a null address, or missing name anywhere
            Customer newCust = new Customer();
            newCust.firstName = firstName;
            newCust.lastName = lastName;
            newCust.customerAddress = testVariable.GetAddress();

            Assert.True(newCust.customerAddress.CheckAddressNotNull() == true);
            Assert.False(newCust.CheckCustomerNotNull() == false);
        }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests if items were properly added to the list of products, then sets it to the inventory. Checks to make sure the inventory properly accepted the list of product.
        //0 is an acceptable amount
        [Theory]
        [InlineData(0, 1, 2)]
        [InlineData(3, 4, 5)]
        public void InventoryCheckReturnsTrue(int burgers, int fries, int soda)
        {
            Product testProductList = new Product();
            Inventory testInventory = testVariable.GetInventory();
            testProductList.burgerAmount = burgers;
            testProductList.friesAmount = fries;
            testProductList.sodaAmount = soda;

            testInventory.productData = testProductList;

            Console.WriteLine("~Testing Variables~\nBurgers: " + testProductList.burgerAmount.ToString()
                + "\nFries: " + testProductList.friesAmount,ToString() + "\nSoda: " + testProductList.sodaAmount.ToString());
            Assert.True(testInventory.productData.CheckInventoryNotNull() == true);
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests if any items are null that are plugged into the used product list. 
        [Theory]
        [InlineData(1, 2, null)]
        [InlineData(5, null, 6)]
        [InlineData(null, 5, 9)]
        public void InventoryCheckReturnsFalse(int burgers, int fries, int soda)
        {
            Product testProductList = new Product();
            Inventory testInventory = testVariable.GetInventory();
            testProductList.burgerAmount = burgers;
            testProductList.friesAmount = fries;
            testProductList.sodaAmount = soda;

            testInventory.productData = testProductList;

            Console.WriteLine("~Testing Variables~\nBurgers: " + testProductList.burgerAmount.ToString()
                + "\nFries: " + testProductList.friesAmount, ToString() + "\nSoda: " + testProductList.sodaAmount.ToString());
            Assert.False(testInventory.productData.CheckInventoryNotNull() == false);
        }

        [Theory]
        [InlineData(00001)]
        [InlineData(null)]
        public void LocationDataCheck(int storeNum)
        {
            Location testLocation = new Location();
            testLocation.address = testVariable.GetAddress();
            testLocation.storeInventory = testVariable.GetInventory();
            testLocation.storeNumber = storeNum;

            if (storeNum == null)
            {
                Assert.False(testLocation.CheckLocationNotNull() == false);
            }
            else
            {
                Assert.True(testLocation.CheckLocationNotNull() == true);
            }
            
        }
        [Theory]
        [InlineData(60)]
        [InlineData(null)]
        public void OrderDataCheck(double time)
        {
            Order testOrder = new Order();
            testOrder.customer = testVariable.GetCustomer();
            testOrder.ordererAddress = testVariable.GetAddress();
            testOrder.orderTime = time;
            testOrder.storeLocation = testVariable.GetLocation();

            if (time == null)
            {
                Assert.False(testOrder.CheckOrderNotNull() == false);
            }
            else
            {
                Assert.True(testOrder.CheckOrderNotNull() == true);
            }
        }
    }
}
