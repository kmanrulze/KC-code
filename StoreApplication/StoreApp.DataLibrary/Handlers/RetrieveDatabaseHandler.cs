using StoreApp.DataLibrary.Entities;
using StoreApplication;
using System;
using System.IO;
using System.Linq;

namespace StoreApplication
{
    public class RetrieveDatabaseHandler
    {
        private string connectionString = File.ReadAllText(@"C:/revature/kc-project0/StoreApplication/StoreApp.DataLibrary/Connection String/string.txt");
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
        public Customer GetCustomerData(int customerID, StoreApplicationContext context)
        {
            //Some code to retrieve a list of customer data
            Customer retrievedCustomer = new Customer();

            try
            {
                foreach (StoreApp.DataLibrary.Entities.Customer customerInDB in context.Customer)
                {
                    if (customerInDB.CustomerId == customerID)
                    {
                        retrievedCustomer.customerAddress.street = customerInDB.Street;
                        retrievedCustomer.customerAddress.city = customerInDB.City;
                        retrievedCustomer.customerAddress.state = customerInDB.State;
                        retrievedCustomer.customerAddress.zip = customerInDB.Zip;

                        retrievedCustomer.customerID = customerInDB.CustomerId;
                        retrievedCustomer.firstName = customerInDB.FirstName;
                        retrievedCustomer.lastName = customerInDB.LastName;

                        return retrievedCustomer;
                    }
                    else
                    {
                        Console.WriteLine("No records of customer with ID of " + customerID);
                        return null;
                    }
                }
                return retrievedCustomer;
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
            return connectionString;
        }
    }
}