using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekdaysEnumExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the current day of the week: ");
            string day = Console.ReadLine().ToUpper();

            //while loop keeps asking for day of the week till user enters a value that is in Weekdays
            bool correct = false;
            while (!correct)
            {
                try
                {
                    //checks if user input matches one of the Weekdays values
                    Enum.Parse(typeof(Weekdays), day);
                    Console.WriteLine("\nThat is a valid day of the week, thank you.");
                    correct = true;
                }
                //error message if user input isn't a Weedays value
                catch (ArgumentException)
                {
                    Console.WriteLine("\nPlease enter an actual day of the week.");
                    day = Console.ReadLine().ToUpper();
                }
            }
            
            Console.ReadLine();
        }
    }

    //creating Weekdays enum with values
    public enum Weekdays
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
        SATURDAY,
        SUNDAY
    }
}
