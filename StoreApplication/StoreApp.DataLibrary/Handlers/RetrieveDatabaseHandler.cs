using StoreApplication;
using System.IO;

namespace StoreApplication
{
    public class RetrieveDatabaseHandler
    {
        public string connectionString = File.ReadAllText(@"C:/revature/kc-project0/StoreApplication/StoreApp.DataLibrary/Connection String/string.txt");
        public string CheckCustomerID()
        {
            //Some code to check information tied to the customer ID
            string pulledID = "";
            return pulledID;
        }
        public string CheckOrderID()
        {
            //Some code to check information tied to the order ID
            string pulledID = "";
            return pulledID;
        }
        public string GetCustomerData(string custID)
        {
            //Some code to retrieve a list of customer data
            string dataString = "";
            return dataString;
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