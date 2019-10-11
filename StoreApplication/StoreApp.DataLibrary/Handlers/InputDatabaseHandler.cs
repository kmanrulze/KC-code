using StoreApp.DataLibrary.Entities;
using StoreApplication;
using System;
using System.IO;
using System.Linq;

namespace StoreApplication
{
    public class InputDatabaseHandler
    {
        private string connectionString = File.ReadAllText(@"C:/revature/kc-project0/StoreApplication/StoreApp.DataLibrary/Connection String/string.txt");
        public void InputOrder(Order order)
        {

        }
        public void AddNewCustomerData(Customer cust)
        {
            //Some code to input customer data to the DB
        }
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
