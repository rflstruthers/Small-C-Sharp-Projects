using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {

            

            Console.WriteLine("Welcome to MATH! a program that performs mathematical operations on your favorite number.\n" +
                "Please enter your favorite number:\n");
            int input = Convert.ToInt32(Console.ReadLine());

            int timesTen = Methods.Multiply(input);
            int plusTen = Methods.Add(input);
            int minusTen = Methods.Subtract(input);

            Console.WriteLine(input + " x 10 = " + timesTen);
            Console.WriteLine(input + " + 10 = " + plusTen);
            Console.WriteLine(input + " - 10 = " + minusTen);


            Console.ReadLine();
        }
    }
}
