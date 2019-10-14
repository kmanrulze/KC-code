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

        public OrderProduct LogicProductToContextProduct(BusinessLogic.Objects.Product BLProd, BusinessLogic.Objects.Order BLOrder)
        {
            Entities.OrderProduct CTXProd = new OrderProduct();

            CTXProd.ProductTypeId = BLProd.productTypeID;
            CTXProd.ProductAmount = BLProd.amount;
            CTXProd.StoreNumber = BLOrder.storeLocation.storeNumber;
            CTXProd.OrderId = BLOrder.orderID;

            return CTXProd;
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

            BLStore.storeNumber = CTXStore.StoreNumber;

            return BLStore;
        }
        public Entities.Orders LogicOrderToContextOrder(StoreApp.BusinessLogic.Objects.Order BLorder)
        {
            Orders CTXOrder = new Orders();

            CTXOrder.CustomerId = BLorder.customer.customerID;

            return CTXOrder;
        }

        public Order ContextOrderToLogicOrder(Entities.Orders CTXOrder, StoreApplicationContext context)
        {
            BusinessLogic.Objects.Order BLOrder = new Order();

#warning not filled in yet
            return null;
        }
        public BusinessLogic.Objects.Product ContextInventoryProductToLogicProduct(InventoryProduct CTXProd)
        {
            BusinessLogic.Objects.Product BLProd = new BusinessLogic.Objects.Product();

            BLProd.productTypeID = CTXProd.ProductTypeId;
            BLProd.amount = CTXProd.ProductAmount;

            return BLProd;
        }

        internal BusinessLogic.Objects.Product ContextOrderProductToLogicProduct(OrderProduct CTXProduct)
        {
            BusinessLogic.Objects.Product BLProduct = new BusinessLogic.Objects.Product();

            BLProduct.productTypeID = CTXProduct.ProductTypeId;
            BLProduct.amount = CTXProduct.ProductAmount;

            return BLProduct;
        }
    }
}
