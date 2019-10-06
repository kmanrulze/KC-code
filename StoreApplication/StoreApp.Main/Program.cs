using System;
using StoreApp.Library;

namespace StoreApp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("StoreApplication ready to take order");

            Console.WriteLine("Please place your order. \n");

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
    }
}
