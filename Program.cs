using System;

namespace KC_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("~Make bool, String, and int variables~\n");

            bool newBool;
            string newString;
            int newInt;

            newBool = true;
            newString = "String message";
            newInt = 12345;

            Console.WriteLine("Boolean: " + newBool.ToString());
            Console.WriteLine("Boolean: " + newString);
            Console.WriteLine("Boolean: " + newInt.ToString());

            Console.WriteLine("~Change the values~");

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

            


            // make bool, string, and int variables (with values)

            // change their values to something else

            // print their values with Console

            // do something in a for loop
            // do something in a while loop
            // do something with a switch statement

            // do something with if, else if, else

            // figure out how to make multi-line comments in C#
            // figure out how to format your document in VS Code

            // extra: make a new static method to do something and call it
            // extra: learn what "var" means in C# and try it out.
        }
    }
}
