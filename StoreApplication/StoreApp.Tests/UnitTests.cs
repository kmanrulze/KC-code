using StoreApp.BusinessLogic.Objects;
using System;
using System.Collections.Generic;
using Xunit;

namespace StoreApp.Tests
{
    public class UnitTests
    {
        private readonly TestVarGeneration testVariable = new TestVarGeneration();

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

            Assert.True(testAddress.CheckAddressNotNull());
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
            Address testAddress = new Address()
            {
                city = city,
                state = state,
                street = street,
                zip = zip
            };

            Assert.False(testAddress.CheckAddressNotNull());
        }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests if any customer data is firstly null, then if any of their address items are null. Passes if everything is in correctly
        //Address is expected to return true. A known good address is being passed in
        [Theory]
        [InlineData("Mary", "Jane", 8)]
        [InlineData("Gary", "Hanes", 4)]
        public void CheckCustomerDataReturnTrue(string firstName, string lastName, int testID)
        {

            Customer newCust = new Customer();
            newCust.firstName = firstName;
            newCust.lastName = lastName;
            newCust.customerAddress = testVariable.GetAddress();
            newCust.customerID = testID;

            Assert.True(newCust.CheckCustomerNotNull());
        }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests if any customer data is firstly null, then if any of their address items are null.
        //Should pass on Assert True for the test address passed in that is a known correct value, and false for the false assert as expected
        [Theory]
        [InlineData(null, "Lanes")]
        [InlineData("Boom", null)]
        public void CheckCustomerDataReturnFalse(string firstName, string lastName)
        {
            //False for having a null address, or missing name anywhere
            Customer newCust = new Customer();
            newCust.firstName = firstName;
            newCust.lastName = lastName;
            newCust.customerAddress = testVariable.GetAddress();
            newCust.customerID = 4;

            Assert.False(newCust.CheckCustomerNotNull());
        }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests if items were properly added to the list of products, then sets it to the inventory. Checks to make sure the inventory properly accepted the list of product.
        //0 is an acceptable amount
        [Theory]
        [InlineData(0, 1, 2)]
        [InlineData(3, 4, 5)]
        public void InventoryCheckReturnsTrue(int burgers, int fries, int soda)
        {
            Inventory testInventory = testVariable.GetInventory();
            testInventory.productData.burgerAmount = burgers;
            testInventory.productData.friesAmount = fries;
            testInventory.productData.sodaAmount = soda;

            Assert.True(testInventory.productData.CheckProductCountNotInvalid());
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Tests false if any items are negative that are plugged into the used product list. 
        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(5, -1, 6)]
        [InlineData(-1, 5, 9)]
        public void InventoryCheckReturnsFalse(int burgers, int fries, int soda)
        {
            Inventory testInventory = testVariable.GetInventory();
            testInventory.productData.burgerAmount = burgers;
            testInventory.productData.friesAmount = fries;
            testInventory.productData.sodaAmount = soda;

            Assert.False(testInventory.productData.CheckProductCountNotInvalid());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(-1)]
        public void LocationDataCheck(int storeNum)
        {
            Location testLocation = new Location();
            testLocation.address = testVariable.GetAddress();
            testLocation.storeInventory = testVariable.GetInventory();
            testLocation.storeNumber = storeNum;

            if (storeNum <= 0)
            {
                Assert.False(testLocation.CheckLocationNotNull());
            }
            else
            {
                Assert.True(testLocation.CheckLocationNotNull());
            }
            
        }
        [Theory]
        [InlineData(60, 12)]
        [InlineData(0, null)]
        [InlineData(-1, 34)]
        public void OrderDataCheck(double time, int testID)
        {
            Order testOrder = testVariable.GetOrder();
            testOrder.customer = testVariable.GetCustomer();
            testOrder.ordererAddress = testVariable.GetAddress();
            testOrder.orderTime = time;
            testOrder.storeLocation = testVariable.GetLocation();
            testOrder.orderID = testID;
            testOrder.customerProductList = testVariable.GetProduct();

            //Asserts test to make sure the default values aren't causing issues, as we are testing the two strings above to make sure it catches those 
            Assert.True(testOrder.customer.CheckCustomerNotNull());
            Assert.True(testOrder.ordererAddress.CheckAddressNotNull());
            Assert.True(testOrder.storeLocation.CheckLocationNotNull());
            Assert.True(testOrder.customerProductList.CheckProductCountNotInvalid());

            if (testOrder.customer.CheckCustomerNotNull() == true && testOrder.ordererAddress.CheckAddressNotNull() == true &&
                testOrder.storeLocation.CheckLocationNotNull() == true && testOrder.customerProductList.CheckProductCountNotInvalid() == true &&
                testOrder.CheckOrderNotNull() == true)
            { 
                Assert.True(testOrder.CheckOrderNotNull());
            }
            else
            {
                Assert.False(testOrder.CheckOrderNotNull());
            }
        }
    }
}
