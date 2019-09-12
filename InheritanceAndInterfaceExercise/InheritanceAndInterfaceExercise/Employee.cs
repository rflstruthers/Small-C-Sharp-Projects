using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndInterfaceExercise
{
    public class Employee : Person, IQuittable
    {
        public int Id { get; set; }

        //Quit method from IQuittable interface
        public void Quit()
        {
            Console.WriteLine("This employee has quit.");
        }
    }
}
