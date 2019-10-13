using Microsoft.EntityFrameworkCore;
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
        private ParseHandler parser = new ParseHandler();
        public void InputOrder(Order BLorder, StoreApplicationContext context)
        {
            try
            {
                context.Orders.Add(parser.LogicOrderToContextOrder(BLorder));
                context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Console.WriteLine("Something went wrong inputting order: " + e);
            }
        }
        public void AddNewCustomerData(StoreApp.BusinessLogic.Objects.Customer BLCustomer, StoreApplicationContext context)
        {
            //Some code to input customer data to the DB

            try
            {
                context.Customer.Add(parser.LogicCustomerToContextCustomer(BLCustomer));
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to put the customer into the database: " + e.Message);
            }
        }
        public void DeleteCustomerByID(int customerID, StoreApplicationContext context)
        {
            //Some code that removes customer from the DB given an ID

            //context.Customer.Remove();
        }
        public string GetConnectionString()
        {
            return Secret.connectionString;
        }
    }
}
