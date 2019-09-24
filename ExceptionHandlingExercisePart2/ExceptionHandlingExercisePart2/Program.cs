using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingExercisePart2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to ACME Health Insurance." +
                "\nPlease enter your age to see if you are eligible for our award winning coverage.");

            //if the user enters digits for their age, store that as "age" and print their birth year to the screen
            //if they enter something other than just digits, throw format exception error
            //if they enter 0 or negative numbers, throw 
            bool validAnswer = false;
            int age = 0;
            while (!validAnswer)
            {
                try
                {
                    age = Convert.ToInt32(Console.ReadLine());
                    validAnswer = true;
                    if (age <= 0) throw new RejectionException();
                }
                catch (RejectionException)
                {
                    Console.WriteLine("Your request for coverage has been rejected. Goodbye.");
                    Console.ReadLine();
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please only enter digits for your age.");
                }
                catch (Exception)
                {
                    Console.WriteLine("An error has occured. Please come back at a later date or contact Customer Service.");
                    Console.ReadLine();
                    return;
                }

            }

            //gets the current year, subtracts users age from current year to get birth year.
            int thisYear = DateTime.Now.Year;
            int birthYear = thisYear - age;
            Console.WriteLine("According to the information you provided, your birth year is {0}, that means you are eligible for our coverage!", birthYear);



            Console.ReadLine();
        }
    }
}


//bool validAnswer = false;
//int age = 0;
//            while (!validAnswer)
//            {
//                Console.WriteLine("Please enter your age to see if you are eligible for our award winning coverage.");
//                validAnswer = int.TryParse(Console.ReadLine(), out age);
//                if (!validAnswer) Console.WriteLine("Please enter digits only.");
//            }
//            Console.WriteLine("\n\n\n\n\n\n" + age);