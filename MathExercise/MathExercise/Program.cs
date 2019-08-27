using System;

namespace MathExercise
{
    class Program
    {
        static void Main()
        {
            //1. Takes an input from the user, multiplies it by 50, and prints the result to the console.
            Console.WriteLine("Please enter a number: ");
            string numInput1 = Console.ReadLine();
            double num1 = Convert.ToDouble(numInput1);
            double numTimes50 = num1 * 50;
            Console.WriteLine(numInput1 + " x 50 = " + numTimes50);

            //2. Takes an input from the user, adds 25 to it, and prints the result to the console.
            Console.WriteLine("\nPlease enter another number: ");
            string numInput2 = Console.ReadLine();
            double num2 = Convert.ToDouble(numInput2);
            double numPlus25 = num2 + 25;
            Console.WriteLine(numInput2 + " + 25 = " + numPlus25);

            //3. Takes an input from the user, divides it by 12.5, and prints the result to the console.
            Console.WriteLine("\nPlease enter yet another number: ");
            string numInput3 = Console.ReadLine();
            double num3 = Convert.ToDouble(numInput3);
            double numDividedBy = num3 / 12.5;
            Console.WriteLine(numInput3 + " / 12.5 = " + numDividedBy);
            
            //4. Takes an input from the user, checks if it is greater than 50, and prints the true/false result to the console.
            Console.WriteLine("\nAgain, please enter a number: ");
            string numInput4 = Console.ReadLine();
            double num4 = Convert.ToDouble(numInput4);
            bool greaterThan50 = num4 > 50;
            Console.WriteLine("Is " + num4 + " > 50?: " + greaterThan50);

            //5. Takes an input from the user, divides it by 7, and prints the remainder to the console (tip: think % operator).
            Console.WriteLine("\nFor the final time, please enter a number: ");
            string numInput5 = Console.ReadLine();
            double num5 = Convert.ToDouble(numInput5);
            double numRemainder = num5 % 7;
            Console.WriteLine("The remainder of " + num5 + " / 7 = " + numRemainder);
            Console.ReadLine();



        }
    }
}
