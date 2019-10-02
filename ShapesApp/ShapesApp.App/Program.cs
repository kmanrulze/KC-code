using System;

namespace ShapesApp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            double length;
            string input;
            do
            {
                Console.WriteLine("Enter a length: ");
                input = System.Console.ReadLine();
            } while (!double.TryParse(input, out length));

            double width;
            
        }
    }
}
