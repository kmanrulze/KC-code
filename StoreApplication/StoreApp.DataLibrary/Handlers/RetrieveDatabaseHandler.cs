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
        public bool CheckParsable(string IDString)
        {

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
            BusinessLogic.Objects.Store BLStore = new BusinessLogic.Objects.Store();
            try
            {
                foreach (StoreApp.DataLibrary.Entities.Store storeLoc in context.Store)
                {
                    if (storeLoc.StoreNumber == storeNum)
                    {
                        BLStore = parser.ContextStoreToLogicStore(storeLoc);
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
                foreach (Entities.Orders order in context.Orders)
                {
                    if (order.CustomerId == custID)
                    {
                        foreach (Entities.OrderProduct ordProd in context.OrderProduct)
                        {
                            if (ordProd.OrderId == order.OrderId)
                            {
                                filledData.customerProductList.Add(parser.ContextOrderProductToLogicProduct(ordProd));
                            }
                        }
                    }
                    foreach (BusinessLogic.Objects.Product product in filledData.customerProductList)
                    {
                        foreach (Entities.Product entProd in context.Product)
                        {
                            if (product.productTypeID == entProd.ProductTypeId)
                            {
                                product.name = entProd.ProductName;
                            }
                        }
                    }
                }
                return listToBeReturned;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation failed: " + e.Message);
                return null;
            }
        }

        public int GetNewCustomerID(StoreApplicationContext context)
        {
            int NewCustID = 0;
            foreach (Entities.Customer cust in context.Customer)
            {
                NewCustID = cust.CustomerId;
            }
            return NewCustID;
        }

        public Inventory GetStoreInventoryByStoreNumber(int storeNumber, StoreApplicationContext context)
        {
            Inventory BLInventory = new Inventory();
            BusinessLogic.Objects.Product BLProduct = new BusinessLogic.Objects.Product();
            try
            {
                foreach (Entities.InventoryProduct prod in context.InventoryProduct)
                {
                    if (prod.StoreNumber == storeNumber)
                    {
                        BLProduct = parser.ContextInventoryProductToLogicProduct(prod);
                        BLInventory.productData.Add(BLProduct);
                        BLProduct = new BusinessLogic.Objects.Product();
                    }
                    else
                    {

                    }
                }
                foreach (BusinessLogic.Objects.Product prod in BLInventory.productData)
                {
                    foreach (Entities.Product entProd in context.Product)
                    {
                        if (prod.productTypeID == entProd.ProductTypeId)
                        {
                            prod.name = entProd.ProductName;
                        }
                    }
                }
                return BLInventory;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to get the list of store inventory items: " + e.Message);
                return null;
            }
        }
    }
}