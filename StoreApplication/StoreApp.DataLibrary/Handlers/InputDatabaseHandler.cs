using StoreApp.BusinessLogic.Objects;
using StoreApp.DataLibrary.Entities;
using System;
using System.IO;
using System.Linq;

namespace StoreApp.DataLibrary.Handlers
{
    public class InputDatabaseHandler
    {
        private string connectionString = File.ReadAllText(@"C:/revature/kc-project0/StoreApplication/StoreApp.DataLibrary/Connection String/string.txt");
        public void InputOrder(Order order)
        {

        }
        public void AddNewCustomerData(StoreApp.BusinessLogic.Objects.Customer cust)
        {
            //Some code to input customer data to the DB
        }
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
