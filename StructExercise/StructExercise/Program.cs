using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number() { Amount = 5.00m };
            Console.WriteLine(number.Amount);
            Console.ReadLine();
        }
    }
}
