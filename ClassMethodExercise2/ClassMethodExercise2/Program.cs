using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodExercise2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //instantiate object "method" of class "Method"
            Method method = new Method();

            //call "AddTwo" method from class "Method"
            method.AddTwo(num1 : 2, times: 5);
        }
    }
}
