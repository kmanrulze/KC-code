using StoreApp.DataLibrary.ConnectionData;
using StoreApp.DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.DataLibrary.Handlers
{
    public class RetrieveDatabaseHandler
    {
        public bool CheckCustomerIDParsable(string IDString)
        {
            //Checks if the ID string input is parsable to an int and returns true or false

            if (IDString.Any(x => !char.IsLetter(x)) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CheckOrderID()
        {
            //Some code to check information tied to the order ID
            string pulledID = "";
            return pulledID;
        }
        public StoreApp.BusinessLogic.Objects.Customer GetCustomerDataFromID(int customerID, StoreApplicationContext context)
        {
            //Some code to retrieve a list of customer data
            List<StoreApp.BusinessLogic.Objects.Customer> retrievedCustomerList = new List<StoreApp.BusinessLogic.Objects.Customer>();

            retrievedCustomerList = GetAllCustomerData(context);

            try
            {
                foreach (StoreApp.BusinessLogic.Objects.Customer cust in retrievedCustomerList)
                {
                    if (cust.customerID.Equals(customerID))
                    {
                        return cust;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation failed: " + e.Message);
                return null;
            }            
        }
        public string GetOrderData(string custID)
        {
            //Some code to retrieve a list of order data
            string dataString = "";
            return dataString;
        }
        public string GetConnectionString()
        {
            return Secret.connectionString;
        }

        //Returns list of customers using the BusinessLogic framework to the method that calls it, given a context
        public List<StoreApp.BusinessLogic.Objects.Customer> GetAllCustomerData(StoreApplicationContext context)
        {
            List<StoreApp.BusinessLogic.Objects.Customer> listOfCustomerData = new List<StoreApp.BusinessLogic.Objects.Customer>();

            foreach (StoreApp.DataLibrary.Entities.Customer customerInDB in context.Customer)
            {
                StoreApp.BusinessLogic.Objects.Customer retrievedCustomer = new StoreApp.BusinessLogic.Objects.Customer();

                retrievedCustomer.customerAddress.street = customerInDB.Street;
                retrievedCustomer.customerAddress.city = customerInDB.City;
                retrievedCustomer.customerAddress.state = customerInDB.State;
                retrievedCustomer.customerAddress.zip = customerInDB.Zip;

                retrievedCustomer.customerID = customerInDB.CustomerId;
                retrievedCustomer.firstName = customerInDB.FirstName;
                retrievedCustomer.lastName = customerInDB.LastName;

                listOfCustomerData.Add(retrievedCustomer);
            }

            return listOfCustomerData;
        }
    }
}