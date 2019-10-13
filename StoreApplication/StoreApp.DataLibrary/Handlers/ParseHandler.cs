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

        public BusinessLogic.Objects.Manager ContextManagerToLogicManager(Entities.Manager CTXman)
        {
            StoreApp.BusinessLogic.Objects.Manager BLMan = new BusinessLogic.Objects.Manager();

            BLMan.managerID = CTXman.ManagerId;
            BLMan.firstName = CTXman.FirstName;
            BLMan.lastName = CTXman.LastName;

            return BLMan;
        }

        public BusinessLogic.Objects.Store ContextStoreToLogicStore(Entities.Store CTXStore)
        {
            StoreApp.BusinessLogic.Objects.Store BLStore = new BusinessLogic.Objects.Store();

            BLStore.address.street = CTXStore.Street;
            BLStore.address.city = CTXStore.City;
            BLStore.address.state = CTXStore.State;
            BLStore.address.zip = CTXStore.Zip;

            BLStore.storeInventory.productData.burgerAmount = CTXStore.BurgerAmount;
            BLStore.storeInventory.productData.friesAmount = CTXStore.FriesAmount;
            BLStore.storeInventory.productData.sodaAmount = CTXStore.SodaAmount;

            BLStore.storeNumber = CTXStore.StoreNumber;

            return BLStore;
        }
        public Entities.Orders LogicOrderToContextOrder(StoreApp.BusinessLogic.Objects.Order BLorder)
        {
            Orders CTXorder = new Orders();
            RetrieveDatabaseHandler DBRHandler = new RetrieveDatabaseHandler();

            CTXorder.BurgerAmount = BLorder.customerProductList.burgerAmount;
            CTXorder.FriesAmount = BLorder.customerProductList.friesAmount;
            CTXorder.SodaAmount = BLorder.customerProductList.sodaAmount;

            CTXorder.StoreNumber = BLorder.storeLocation.storeNumber;
            CTXorder.CustomerId = BLorder.customer.customerID;


            return CTXorder;
        }

        public Order ContextOrderToLogicOrder(Entities.Orders CTXorder, StoreApplicationContext context)
        {
            BusinessLogic.Objects.Order BLOrder = new Order();

            BLOrder.orderID = CTXorder.OrderId;
            BLOrder.storeLocation.storeNumber = CTXorder.StoreNumber;

            BLOrder.customer.customerID = CTXorder.CustomerId;
            BLOrder.customer.customerAddress.street = CTXorder.Customer.Street;
            BLOrder.customer.customerAddress.city = CTXorder.Customer.City;
            BLOrder.customer.customerAddress.state = CTXorder.Customer.State;
            BLOrder.customer.customerAddress.zip = CTXorder.Customer.Zip;

            BLOrder.customer.firstName = CTXorder.Customer.FirstName;
            BLOrder.customer.lastName = CTXorder.Customer.LastName;

            BLOrder.ordererAddress.street = CTXorder.Customer.Street;
            BLOrder.ordererAddress.city = CTXorder.Customer.City;
            BLOrder.ordererAddress.state = CTXorder.Customer.State;
            BLOrder.ordererAddress.zip = CTXorder.Customer.Zip;

            BLOrder.customerProductList.burgerAmount = CTXorder.BurgerAmount;
            BLOrder.customerProductList.friesAmount = CTXorder.FriesAmount;
            BLOrder.customerProductList.sodaAmount = CTXorder.SodaAmount;

            return BLOrder;
        }
    }
}
