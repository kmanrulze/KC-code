using StoreApp.BusinessLogic.Objects;
using StoreApp.DataLibrary.ConnectionData;
using StoreApp.DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.DataLibrary.Handlers
{
    public class RetrieveDatabaseHandler
    {
        private ParseHandler parser = new ParseHandler();
        public bool CheckIDParsable(string IDString)
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
        public StoreApp.BusinessLogic.Objects.Customer GetCustomerDataFromID(int customerID, StoreApplicationContext context)
        {
            //Some code to retrieve a list of customer data

            try
            {
                foreach (StoreApp.DataLibrary.Entities.Customer cust in context.Customer)
                {
                    if (cust.CustomerId == customerID)
                    {
                        StoreApp.BusinessLogic.Objects.Customer matchingCustomer = parser.ContextCustomerToLogicCustomer(cust);
                        return matchingCustomer;
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

                listOfCustomerData.Add(retrievedCustomer);
            }

            return listOfCustomerData;
        }

        public BusinessLogic.Objects.Manager GetManagerDataFromID(int managerID, StoreApplicationContext context)
        {

            try
            {
                foreach (StoreApp.DataLibrary.Entities.Manager man in context.Manager)
                {
                    if (man.ManagerId == managerID)
                    {
                        return parser.ContextManagerToLogicManager(man);
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

        public BusinessLogic.Objects.Store GetStoreFromStoreNumber(int storeNum, StoreApplicationContext context)
        {
            try
            {
                foreach (StoreApp.DataLibrary.Entities.Store storeLoc in context.Store)
                {
                    if (storeLoc.StoreNumber == storeNum)
                    {
                        return parser.ContextStoreToLogicStore(storeLoc);
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
        public List<StoreApp.BusinessLogic.Objects.Order> GetListOfOrdersByCustomerID(int custID, StoreApplicationContext context)
        {
            List<Order> listToBeReturned = new List<Order>();
            Order filledData = new Order();

            try
            {
                foreach (StoreApp.DataLibrary.Entities.Orders Order in context.Orders)
                {
                    if (Order.CustomerId == custID)
                    {
                        filledData = parser.ContextOrderToLogicOrder(Order, context);
                        filledData.customer = GetCustomerDataFromID(filledData.customer.customerID, context);
                        filledData.ordererAddress = GetCustomerDataFromID(filledData.customer.customerID, context).customerAddress;
                        filledData.storeLocation = GetStoreFromStoreNumber(filledData.storeLocation.storeNumber, context);

                        listToBeReturned.Add(filledData);
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
    }
}