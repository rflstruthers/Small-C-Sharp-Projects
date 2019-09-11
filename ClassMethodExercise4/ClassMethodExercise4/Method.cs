using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise4
{
    public class Method
    {
        //method takes in two integers, one of which is optional, and returns an integer
        public int OptionalMethod(int num1, int num2 = 0)
        {
            int result = (num1 * 10) + num2;
            return result;
        }

        public int Result { get; set; }
    }
}
