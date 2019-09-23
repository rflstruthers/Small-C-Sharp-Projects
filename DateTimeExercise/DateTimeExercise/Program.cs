using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("Hello, it is currently {0}", dateTime);
            Console.WriteLine("\nPlease enter a number of hours:");
            try
            {
                double hours = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nIn {0} hours it will be exactly {1}", hours, dateTime.AddHours(hours));
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a number of hours");
            }
            Console.ReadLine();
        }
    }
}
