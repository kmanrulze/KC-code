using System;
using System.Collections.Generic;

namespace MiscProj
{
    class Program
    {
        static void Main(string[] args)
        {
            //Typecsting
            int five = 5;
            double otherFive = five;
            int nextFive = (int)otherFive;

            // converstions when type heirarchies are concerned
            var list = new List<int>();
            object o = list; // implicit upcasting
        }
    }
}
