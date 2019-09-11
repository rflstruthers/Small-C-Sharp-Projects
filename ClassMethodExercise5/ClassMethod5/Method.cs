using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethod5
{
    public class Method
    {

        

        public void Divide(int input, out string dollar)
        {
            dollar = " dollars.";
            int result = input / 2;
            Console.WriteLine("\nSorry, you had " + input + " dollars, but now you only have " + result + dollar);
        }

        public void Divide(int input, int bonus, out string dollar)
        {
            dollar = " dollars";
            int result = input / 2;
            int newResult = result + bonus;
            Console.WriteLine("\nWe made half your money dissapear!\nBut dont worry!" +
                " For using this program, you are getting " + bonus + dollar + "!\nNow you have " + newResult + dollar + "!");
        }


    }
}
