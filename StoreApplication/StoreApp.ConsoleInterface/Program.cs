using System;
using StoreApp.DataLibrary;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Linq;
using StoreApp.BusinessLogic;
using StoreApp.DataLibrary;
using StoreApp.DataLibrary.Handlers;
using System.Collections.Generic;

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
            bool check = true;

            //DB initialization

            string connectionString = DBRHandler.GetConnectionString();
            DbContextOptions<StoreApplicationContext> options = new DbContextOptionsBuilder<StoreApplicationContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new StoreApplicationContext(options);

            while (whileBool == true)
            {
                Console.WriteLine("Are you using this console as a manager or a customer?\n[1] Manager\n[2] Customer\n");
                initialInput = CheckAndReturnCustomerOptionChosen(Console.ReadLine(), 2);

                if (initialInput == "1") //Manager
                {
                    string managerIDInput;
                    int managerID;
                    //code for manager
                    //Can display current stocks and things for locations and other things stored
                    //Managment can stock their stores and check and edit customer data


                    while (check == true)
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
                                check = false;
                                whileBool = false;
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

                    //Some code to compare manager ID to the table and welcome manager options

                }
                else if (initialInput == "2") //Customer
                {
                    //code for customer
                    //Will run code to make new customer, retrieve old customer data, and place orders
                    Console.WriteLine("Welcome! Are you a returning customer?\n[1] Yes\n[2] No\n");
                    secondaryInput = CheckAndReturnCustomerOptionChosen(Console.ReadLine(), 2);
                    whileBool = false;
                }
                else //Invalid input
                {
                    Console.WriteLine("Invalid input, please type one of the following options");
                }
            }
            //------------------------------------------------------------------------------------------------------------------
            whileBool = true;
            check = true;
            while (whileBool == true)//Returning Customer or New Customer
            {
                if (secondaryInput == "1") //Returning Customer
                {
                    int customerID;
                    

                    while (check == true)
                    {
                        Console.WriteLine("Welcome back! What is your customer ID?");
                        secondaryInput = Console.ReadLine();

                        if (DBRHandler.CheckIDParsable(secondaryInput) == false)
                        {
                            Console.WriteLine("Invalid characters. Please try again with a numerical value");
                            break;

                        }
                        else //if the input only has numbers in it
                        {
                            customerID = Int32.Parse(secondaryInput);

                            try
                            {
                                StoreApp.BusinessLogic.Objects.Customer retrievedCustomer = DBRHandler.GetCustomerDataFromID(customerID, context);
                                Console.WriteLine("Welcome back, " + retrievedCustomer.firstName + " " + retrievedCustomer.lastName + "! What can we do for you today?");
                                check = false;
                                whileBool = false;
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
                }
                else if (secondaryInput == "2") // New Customer
                {
                    StoreApp.BusinessLogic.Objects.Customer newCust = new StoreApp.BusinessLogic.Objects.Customer();

                    while (check == true)
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
                }
            }
            //Bracket end for while loop 


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
