using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethod5
{
    class Program
    {
        static void Main(string[] args)
        {
            Method method = new Method();

            Console.WriteLine("Enter how many dollars you have to see half of it dissapear: ");
            int input = Convert.ToInt32(Console.ReadLine());
            
            method.Divide(input, out string dollar);

            Console.WriteLine("Now enter the current year for some good news...");
            int bonus = Convert.ToInt32(Console.ReadLine());

            method.Divide(input, bonus, out dollar);

            Console.WriteLine("\n\nAnd for some extra good news, enter your birth year:");
            int yearBorn = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("We are giving you a bonus " + Extra.MoreMoney(yearBorn) + " dollars for your trouble!");

            Console.ReadLine();
        }
    }
}
