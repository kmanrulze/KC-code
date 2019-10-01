using System;

namespace KC_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            Console.WriteLine("~Make bool, String, and int variables~");

            bool newBool;
            string newString;
            int newInt;

            newBool = true;
            newString = "String message";
            newInt = 12345;

            Console.WriteLine("Boolean: " + newBool.ToString());
            Console.WriteLine("Boolean: " + newString);
            Console.WriteLine("Boolean: " + newInt.ToString());

            Console.WriteLine("\n~Change the values~");

            newBool = false;
            newString = "New string message";
            newInt = 678910;

            Console.WriteLine("Boolean: " + newBool.ToString());
            Console.WriteLine("Boolean: " + newString);
            Console.WriteLine("Boolean: " + newInt.ToString());

            Console.WriteLine("~Loops~");
            Console.WriteLine("\nFor Loop:");

            for (int i = 0; i<10; i++)
            {
                Console.WriteLine("For loop iteration number " + i.ToString());
            }

            Console.WriteLine("\nWhile Loop");

            int x = 0;
            while (x != 10)
            {
                Console.WriteLine("While loop iteration number " + x.ToString());
                x++;
            }

            Console.WriteLine("\nSwitch Statement");

            int conditionNumber = 1;

            while (conditionNumber !=4)
            {
                switch (conditionNumber)
                    {
                        case 1:
                            Console.WriteLine("Case 1");
                            break;
                        case 2:
                            Console.WriteLine("Case 2");
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                conditionNumber += 1;
            }

            Console.WriteLine("~Method~");
            Console.WriteLine("2 + 3 = " + newMethod(2,3).ToString());
        }
        public static int newMethod(int x, int y)
        {
            int z = x+y;
            return z;
        }
    }
}
