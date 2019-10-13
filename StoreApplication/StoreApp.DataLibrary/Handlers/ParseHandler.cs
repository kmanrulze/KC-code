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

        internal Entities.Customer LogicCustomerToContextCustomer(BusinessLogic.Objects.Customer BLCustomer)
        {
            Entities.Customer CTXCustomer= new Entities.Customer();

            CTXCustomer.FirstName = BLCustomer.firstName;
            CTXCustomer.LastName = BLCustomer.lastName;
            CTXCustomer.Street = BLCustomer.customerAddress.street;
            CTXCustomer.City = BLCustomer.customerAddress.city;
            CTXCustomer.State = BLCustomer.customerAddress.state;
            CTXCustomer.Zip = BLCustomer.customerAddress.zip;

            return CTXCustomer;
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
            Orders CTXOrder = new Orders();

            CTXOrder.BurgerAmount = BLorder.customerProductList.burgerAmount;
            CTXOrder.FriesAmount = BLorder.customerProductList.friesAmount;
            CTXOrder.SodaAmount = BLorder.customerProductList.sodaAmount;

            CTXOrder.StoreNumber = BLorder.storeLocation.storeNumber;
            CTXOrder.CustomerId = BLorder.customer.customerID;


            return CTXOrder;
        }

        public Order ContextOrderToLogicOrder(Entities.Orders CTXOrder, StoreApplicationContext context)
        {
            BusinessLogic.Objects.Order BLOrder = new Order();

            BLOrder.orderID = CTXOrder.OrderId;
            BLOrder.storeLocation.storeNumber = CTXOrder.StoreNumber;

            BLOrder.customer.customerID = CTXOrder.CustomerId;
            BLOrder.customer.customerAddress.street = CTXOrder.Customer.Street;
            BLOrder.customer.customerAddress.city = CTXOrder.Customer.City;
            BLOrder.customer.customerAddress.state = CTXOrder.Customer.State;
            BLOrder.customer.customerAddress.zip = CTXOrder.Customer.Zip;

            BLOrder.customer.firstName = CTXOrder.Customer.FirstName;
            BLOrder.customer.lastName = CTXOrder.Customer.LastName;

            BLOrder.ordererAddress.street = CTXOrder.Customer.Street;
            BLOrder.ordererAddress.city = CTXOrder.Customer.City;
            BLOrder.ordererAddress.state = CTXOrder.Customer.State;
            BLOrder.ordererAddress.zip = CTXOrder.Customer.Zip;

            BLOrder.customerProductList.burgerAmount = CTXOrder.BurgerAmount;
            BLOrder.customerProductList.friesAmount = CTXOrder.FriesAmount;
            BLOrder.customerProductList.sodaAmount = CTXOrder.SodaAmount;

            return BLOrder;
        }
    }
}
