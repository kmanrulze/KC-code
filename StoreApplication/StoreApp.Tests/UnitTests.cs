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

        [Theory]
        [InlineData(2)]
        [InlineData(-1)]
        public void LocationDataCheck(int storeNum)
        {
            Store testLocation = new Store();
            testLocation.address = testVariable.GetAddress();
            testLocation.storeInventory = testVariable.GetInventory();
            testLocation.storeNumber = storeNum;

            if (storeNum == 0 || storeNum <= 0)
            {
                Assert.False(testLocation.CheckLocationNotNull());
            }
            else
            {
                Assert.True(testLocation.CheckLocationNotNull());
            }
            
        }
    }
}
