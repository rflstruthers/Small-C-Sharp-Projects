using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise2
{
    public class Method
    {
        //void method doesnt return a value
        //takes 2 integers as input parameters
        public void AddTwo(int num1, int times)
        {
            for (int i = 0; i < times; i++)
            {
                int result = num1 + 2;
            }
            Console.WriteLine("We added 2 to {0}. We did it {1} times", num1, times);
            
            Console.ReadLine();
        }

        public int Result { get; set; }
    }
}
