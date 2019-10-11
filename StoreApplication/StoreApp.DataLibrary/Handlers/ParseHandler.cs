using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BusinessLogic.Objects;
using StoreApp.DataLibrary.Entities;

namespace StoreApp.DataLibrary.Handlers
{
    public class ParseHandler
    {
        public StoreApp.BusinessLogic.Objects.Customer ContextCustomerToLogicCustomer(StoreApp.DataLibrary.Entities.Customer CTXCustomer)
        {
            StoreApp.BusinessLogic.Objects.Customer BLCustomer = new BusinessLogic.Objects.Customer();

            BLCustomer.customerAddress.street = CTXCustomer.Street;
            BLCustomer.customerAddress.city = CTXCustomer.City;
            BLCustomer.customerAddress.state = CTXCustomer.State;
            BLCustomer.customerAddress.zip = CTXCustomer.Zip;

            BLCustomer.customerID = CTXCustomer.CustomerId;
            BLCustomer.firstName = CTXCustomer.FirstName;
            BLCustomer.lastName = CTXCustomer.LastName;

            return BLCustomer;
        }

        internal BusinessLogic.Objects.Manager ContextManagerToLogicManager(Entities.Manager CTXman)
        {
            StoreApp.BusinessLogic.Objects.Manager BLMan = new BusinessLogic.Objects.Manager();

            BLMan.managerID = CTXman.ManagerId;
            BLMan.firstName = CTXman.FirstName;
            BLMan.lastName = CTXman.LastName;

            return BLMan;
        }
    }
}
