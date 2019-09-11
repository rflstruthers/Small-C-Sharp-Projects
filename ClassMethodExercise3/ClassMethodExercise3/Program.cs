using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            int timesTen = methods.MathMethod(33);
            int divideTen = methods.MathMethod(33.33m);
            int plusTen = methods.MathMethod("10");

            Console.WriteLine("Integer input x 10 = " + timesTen);
            Console.WriteLine("Decimal input / 10 = " + divideTen);
            Console.WriteLine("String input + 10 = " + plusTen);

            Console.ReadLine();
        }
    }
}
