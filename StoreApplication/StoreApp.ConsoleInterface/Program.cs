using System;
using StoreApp.DataAccess;
using StoreApp.Library;
using StoreApplication;
using System.Data.SqlClient;

namespace StoreApp.Main
{
    class Program
    {
        public static RetrieveDatabaseHandler DBRHandler = new RetrieveDatabaseHandler();
        public static InputDatabaseHandler DBIHandler = new InputDatabaseHandler();
        static void Main(string[] args)
        {

            Console.WriteLine("Hello!");

            string initialInput = "0";
            string secondaryInput = "0";
            bool whileBool = true;

            while (whileBool == true)
            {
                Console.WriteLine("Are you using this console as a manager or a customer?\n[1] Manager\n[2] Customer\n");
                initialInput = Console.ReadLine();

                if (initialInput == "1")
                {
                    //code for manager
                    //Can display current stocks and things for locations and other things stored
                    //Managment can stock their stores and check and edit customer data
                    break;

                }
                else if (initialInput == "2")
                {
                    //code for customer
                    //Will run code to make new customer, retrieve old customer data, and place orders
                    Console.WriteLine("Welcome! Are you a returning customer?\n[1] Yes\n[2] No\n");
                    secondaryInput = Console.ReadLine();
                    whileBool = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type one of the following options");
                }
            }
            // Number 2 selected
            whileBool = true;
            if (secondaryInput == "2")
            {
                Customer newCust = new Customer();

                while (whileBool == true)
                {

                    if (newCust.CheckCustomerNotNull() == false)
                    {
                        if (newCust.firstName == null)
                        {
                            Console.WriteLine("What is your first name?");
                            newCust.firstName = Console.ReadLine();
                        }
                        else if (newCust.lastName == null)
                        {
                            Console.WriteLine("What is your last name?");
                            newCust.lastName = Console.ReadLine();
                        }
                        else if (newCust.customerAddress.CheckAddressNotNull() == false)
                        {
                            Console.WriteLine("Please enter an address. What is your street?");
                            newCust.customerAddress.street = Console.ReadLine();

                            Console.WriteLine("Please enter a city");
                            newCust.customerAddress.city = Console.ReadLine();

                            Console.WriteLine("Please enter a state");
                            newCust.customerAddress.state = Console.ReadLine();

                            Console.WriteLine("Please enter a zip");
                            newCust.customerAddress.zip = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Customer profile successfully created! Welcome, " + newCust.firstName + "!");
                        DBIHandler.AddNewCustomerData(newCust);
                        break;

                    }
                }
            }
            else
            {
                //some code for returning customers
            }

        }
        public static void PlaceOrder()
        {
            Console.WriteLine("How many burgers would you like? : ");
            string input = Console.ReadLine();
            int burger = Int32.Parse(input);

            Console.WriteLine("How many fries would you like? : ");
            input = Console.ReadLine();
            int fries = Int32.Parse(input);

            Console.WriteLine("How many sodas would you like? : ");
            input = Console.ReadLine();
            int soda = Int32.Parse(input);
        }
        public static void CreateNewCustomer()
        {
            Customer newCust = new Customer();

            bool whileBool = true;
            string inputString;

            while (whileBool == true)
            {
                if (newCust.CheckCustomerNotNull() == false)
                {
                    if (newCust.firstName == null)
                    {
                        Console.WriteLine("What is your first name?");
                        newCust.firstName = Console.ReadLine();
                    }
                    else if (newCust.lastName == null)
                    {
                        Console.WriteLine("What is your last name?");
                        newCust.lastName = Console.ReadLine();
                    }
                    else if(newCust.customerAddress.CheckAddressNotNull() == false)
                    {
                        Console.WriteLine("Please enter an address. What is your street?");
                        newCust.customerAddress.street = Console.ReadLine();

                        Console.WriteLine("Please enter a city");
                        newCust.customerAddress.city = Console.ReadLine();

                        Console.WriteLine("Please enter a state");
                        newCust.customerAddress.state = Console.ReadLine();

                        Console.WriteLine("Please enter a zip");
                        newCust.customerAddress.zip = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Customer profile successfully created! Welcome, " + newCust.firstName + "!");
                    DBIHandler.AddNewCustomerData(newCust);
                    break;
                    
                }
            }
            
        }
    }
}
