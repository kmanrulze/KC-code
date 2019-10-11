using StoreApp.BusinessLogic.Objects;
using StoreApp.DataLibrary.ConnectionData;
using StoreApp.DataLibrary.Entities;
using System;
using System.IO;
using System.Linq;

namespace StoreApp.DataLibrary.Handlers
{
    public class InputDatabaseHandler
    {
        public void InputOrder(Order order)
        {

        }
        public void AddNewCustomerData(StoreApp.BusinessLogic.Objects.Customer inputedCustomer, StoreApplicationContext context)
        {
            //Some code to input customer data to the DB

            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to put the customer into the database.");
            }
        }
        public string GetConnectionString()
        {
            return Secret.connectionString;
        }
    }
}
