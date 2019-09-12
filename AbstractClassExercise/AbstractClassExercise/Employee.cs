using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExercise
{
    public class Employee : Person
    {
        //implement SayName method from Person class
        public override void SayName()
        {
            Console.WriteLine("Hello, " + FirstName + " " + LastName);
        }
    }
}
