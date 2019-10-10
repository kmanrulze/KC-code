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
            //Some code to add an order to a DB
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();

            //Command here
            command.CommandText = @"INSERT
            
            ";
            command.Parameters.AddWithValue("@FirstName");
            command.Parameters.AddWithValue("@LastName");

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                
            }
         
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
