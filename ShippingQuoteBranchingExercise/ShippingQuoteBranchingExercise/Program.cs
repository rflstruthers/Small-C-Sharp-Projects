using System;

namespace ShippingQuoteBranchingExercise
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.\n");
            Console.WriteLine("Please enter package weight:");
            double weight = Convert.ToDouble(Console.ReadLine());
            if (weight > 50)
            {
                Console.WriteLine("\nPackage too heavy to be shipped via Package Express. Have a good day.");
            }
            else
            {
                Console.WriteLine("\nPlease enter package width:");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nPlease enter package length:");
                double length = Convert.ToDouble(Console.ReadLine());
                double dimensions = (width + length);
                if (dimensions > 50)
                {
                    Console.WriteLine("\nPackage too big to be shipped via Package Express.");
                }
                else
                {
                    double quote = (dimensions * weight) / 100;
                    Console.WriteLine("\nYour estimated shipping total is: $" + String.Format("{0:0.00}", quote) + ".\nThank you.");
                }
            }


            Console.ReadLine();
        }
    }
}
