using System;
using StoreApp.Library;
using StoreApplication;

namespace StoreApp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            StartMenuOptions();
            PlaceOrder();
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
        public static void StartMenuOptions()
        {
            string initialInput = "0";
            string secondaryInput = "0";

            bool inputBool = true;
            while (inputBool == true)
            {
                Console.WriteLine("Are you using this console as a manager or a customer?\n[1] Manager\n[2] Customer\n");
                initialInput = Console.ReadLine();

                if (initialInput == "1")
                {
                    //code for manager
                    //Can display current stocks and things for locations and other things stored
                    //Managment can stock their stores and check and edit customer data

                }
                else if (initialInput == "2")
                {
                    //code for customer
                    //Will run code to make new customer, retrieve old customer data, and place orders
                    Console.WriteLine("Welcome! Are you a returning customer?\n[1] Yes\n[2] No\n");
                    secondaryInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid input, please type one of the following options");
                }
            }
        }
    }
}
