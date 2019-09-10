using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise
{
    public class Methods
    {
        public static int Multiply(int input)
        {
            int timesTen = input * 10;
            return timesTen;
        }

        public static int Add(int input)
        {
            int plusTen = input + 10;
            return plusTen;
        }

        public static int Subtract(int input)
        {
            int minusTen = input - 10;
            return minusTen;
        }

        public int Result { get; set; }
    }
}
