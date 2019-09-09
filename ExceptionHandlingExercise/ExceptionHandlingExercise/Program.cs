using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Create a list of integers.Ask the user for a number to divide each number in the list by.Write a loop that 
//    takes each integer in the list, divides it by the number the user entered, and displays the result to the screen.

//2. Run that code, entering in non-zero numbers as the user.Look at the displayed results.

//3. Run that code, entering in zero as the number to divide by.Note any error messages you get.

//4. Run that code, entering in a string as the number to divide by.Note any error messages you get.

//5. Now put the loop in a try/catch block.Below and outside of the try/catch block, make the program display a 
//    message to the display to let you know the program has emerged from the try/catch block and continued on with 
//    program execution.In the catch block, display the error message to the screen.Then try various combinations of user 
//    input: valid numbers, zero and a string. Ensure the proper error messages display on the screen, and that the code 
//    after the try/catch block gets executed.

namespace ExceptionHandlingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> numbers = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
                Console.WriteLine("Enter a whole number that is not zero: ");
                int input = Convert.ToInt32(Console.ReadLine());
                foreach (int number in numbers)
                {
                    int result = number / input;
                    Console.WriteLine(number + " / " + input + " = " + result);
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Please do not enter zero.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a whole number.");
            }
            finally
            {
                Console.WriteLine("The program is now over.");
                Console.ReadLine();
            }
        }
    }
}
