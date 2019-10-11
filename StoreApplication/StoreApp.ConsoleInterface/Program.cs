using System;
using StoreApp.DataLibrary;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Linq;
using StoreApp.BusinessLogic;
using StoreApp.DataLibrary;
using StoreApp.DataLibrary.Handlers;
using System.Collections.Generic;
using StoreApp.DataLibrary.Entities;

namespace StoreApp.Main
{
    class Program
    {
        public static RetrieveDatabaseHandler DBRHandler = new RetrieveDatabaseHandler();
        public static InputDatabaseHandler DBIHandler = new InputDatabaseHandler();
        static void Main(string[] args)
        {

            Console.WriteLine("Hello! Welcome to the store application!");

            string inputOne = "0";
            string inputTwo = "0";

            //1 - start menu
            //2 - manager menu
            //3 - customer menu
            //4 - return customer menu
            //5 - new customer menu
            //6 - customer options menu
            //7 - manager store view menu
            //8 - order menu

            int menuSwitch = 1;
            bool whileInMenu = true;
            bool whileInSecondaryMenu = true;

            //DB initialization

            string connectionString = DBRHandler.GetConnectionString();
            DbContextOptions<StoreApplicationContext> options = new DbContextOptionsBuilder<StoreApplicationContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new StoreApplicationContext(options);
            while (whileInMenu)
            {
                string managerIDInput;
                int managerID;
                int customerID;
                switch (menuSwitch)
                {
                    case 1: //Start menu
                        while (whileInSecondaryMenu)
                        {
                            Console.WriteLine("Are you using this console as a manager or a customer?\n[1] Manager\n[2] Customer\n");
                            inputOne = CheckAndReturnCustomerOptionChosen(Console.ReadLine(), 2);

                            if (inputOne == "1") //Manager
                            {

                                //code for manager
                                //Can display current stocks and things for locations and other things stored
                                //Managment can stock their stores and check and edit customer data

                                whileInSecondaryMenu = false;
                                menuSwitch = 2;
                            }
                            else if (inputOne == "2") //Customer
                            {
                                //code for customer
                                //Will run code to make new customer, retrieve old customer data, and place orders
                                menuSwitch = 3;
                                whileInSecondaryMenu = false;
                            }
                            else //Invalid input
                            {
                                Console.WriteLine("Invalid input, please type one of the following options");
                            }
                        }
                        whileInSecondaryMenu = true; //resets menu true to go into next menu
                        break;
                    case 2: // manager menu
                        //Some code to compare manager ID to the table and welcome manager options
                        while (whileInSecondaryMenu)
                        {
                            Console.WriteLine("What is your manager ID?");
                            managerIDInput = Console.ReadLine();

                            if (DBRHandler.CheckIDParsable(managerIDInput) == false)
                            {
                                Console.WriteLine("Invalid characters. Please try again with a numerical value");
                                break;

                            }
                            else //if the input only has numbers in it
                            {
                                managerID = Int32.Parse(managerIDInput);

                                try
                                {
                                    StoreApp.BusinessLogic.Objects.Manager retrievedManager = DBRHandler.GetManagerDataFromID(managerID, context);
                                    Console.WriteLine("Welcome back, " + retrievedManager.firstName + " " + retrievedManager.lastName + "! What can we do for you today?");
                                    whileInSecondaryMenu = false;
                                    //set case to go to the manager options menu on 7
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine("Unable to perform the operation due to null value returned with Customer ID " + managerID + ": " + e.Message + "\n");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Unknown exeption " + e);
                                }
                            }
                        }
                        whileInSecondaryMenu = true; //resets menu true to go into next menu
                        break;
                    case 3: //general customer menu
                        while (whileInSecondaryMenu)
                        {
                            Console.WriteLine("Are you a new customer or a return customer?\n[1] New Customer\n[2] Return Customer\n");
                            inputOne = CheckAndReturnCustomerOptionChosen(Console.ReadLine(), 2);

                            if (inputOne == "1")
                            {
                                whileInSecondaryMenu = false;
                                menuSwitch = 5;
                            }
                            else if (inputOne == "2")
                            {
                                whileInSecondaryMenu = false;
                                menuSwitch = 4;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please type one of the following options");
                            }
                        }
                        whileInSecondaryMenu = true;
                        break;
                    case 4: //return customer
                        while (whileInSecondaryMenu)
                        {
                            Console.WriteLine("Welcome back! What is your customer ID?");
                            inputTwo = Console.ReadLine();

                            if (DBRHandler.CheckIDParsable(inputTwo) == false)
                            {
                                Console.WriteLine("Invalid characters. Please try again with a numerical value");
                                break;

                            }
                            else //if the input only has numbers in it
                            {
                                customerID = Int32.Parse(inputTwo);

                                try
                                {
                                    StoreApp.BusinessLogic.Objects.Customer retrievedCustomer = DBRHandler.GetCustomerDataFromID(customerID, context);
                                    Console.WriteLine("Welcome back, " + retrievedCustomer.firstName + " " + retrievedCustomer.lastName + "! What can we do for you today?");
                                    menuSwitch = 6;
                                    whileInSecondaryMenu = false;
                                }
                                catch (NullReferenceException e)
                                {
                                    Console.WriteLine("Unable to perform the operation due to null value returned with Customer ID " + customerID + ": " + e.Message + "\n");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Unknown exeption " + e);
                                }
                            }
                        }
                        whileInSecondaryMenu = true; //resets menu true to go into next menu
                        break;
                    case 5: //new customer menu
                        StoreApp.BusinessLogic.Objects.Customer newCust = new StoreApp.BusinessLogic.Objects.Customer();

                        while (whileInSecondaryMenu)
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
                                try
                                {
                                    Console.WriteLine("Customer profile successfully created! Welcome, " + newCust.firstName + "!");
                                    DBIHandler.AddNewCustomerData(newCust, context);
                                    break;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Unknown exception thrown: " + e);
                                }

                            }
                        }
                        whileInSecondaryMenu = true; //resets menu true to go into next menu
                        break;
                    case 6: //customer options menu
                        while(whileInSecondaryMenu)
                        {

                        }
                        whileInSecondaryMenu = true; //resets menu true to go into next menu
                        break;
                }
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

        //Used for checking menue options are not null or invalid given the input, and the max number of options on a given menue
        public static string CheckAndReturnCustomerOptionChosen(string input, int maxNum)
        {
            bool correctInput = false;
            int inputInt;

            while(correctInput == false)
            {
                if (input == null)
                {
                    Console.WriteLine("Invalid input. Insert correct input option\n");
                    return null;
                }
                else
                {
                    foreach (char thing in input)
                    {
                        if (thing < '0' || thing > '9')
                        {
                            Console.WriteLine("Invalid input. Only insert a number option\n");
                            return null;
                        }
                        else
                        {
                            inputInt = Int32.Parse(input);
                            if (inputInt > maxNum)
                            {
                                Console.WriteLine("Invalid input. Insert correct number from the list above\n");
                                return null;
                            }
                            else
                            {
                                return input;
                            }
                        }
                    }
                }
            }

            return input;
        }
    }
}
