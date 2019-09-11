using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise3
{
    public class Methods
    {
        //method takes in an integer and returns an integer
        public int MathMethod(int input)
        {
            int timesTen = input * 10;
            return timesTen;
        }

        //method takes in a decimal and returns an integer
        public int MathMethod(decimal input)
        {
            int divideTen = Convert.ToInt32(input / 10);
            return divideTen;
        }

        //method takes in a string and returns an integer
        public int MathMethod(string input)
        {
            int plusTen = (Int32.Parse(input)) + 10;
            return plusTen;
        }

        public int Result { get; set; }
    }
}
