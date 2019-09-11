using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Method method = new Method();

            Console.WriteLine("Please enter a number that you want multiplied by 10:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("If you wish, enter a number to be added to the result, you may leave blank if you wish:");

            //Determines if second input is a number or not, if it is it is passed in to method as parameter "num2"
            string input = Console.ReadLine();
            int num2 = -1;
            if (!int.TryParse(input, out num2))
            {
                Console.WriteLine(method.OptionalMethod(num1));
            }
            else
            {
                Console.WriteLine(method.OptionalMethod(num1, num2));

            }


            //if (string.IsNullOrEmpty(Console.ReadLine()))
            //{
            //    Console.WriteLine(method.OptionalMethod(num1));
            //}
            //else
            //{
            //    int num2 = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine(method.OptionalMethod(num1, num2));
            //}
           
            Console.ReadLine();
        }
    }
}
