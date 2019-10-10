using StoreApplication;
using System.IO;
using System.Data.SqlClient;

namespace StoreApp.DataAccess
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
