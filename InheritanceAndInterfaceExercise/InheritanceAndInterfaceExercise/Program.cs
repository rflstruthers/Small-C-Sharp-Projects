using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndInterfaceExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instatiating Employee class with first and last name values
            Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };

            //calling superclass method SayName() on employee object
            employee.SayName();

            //Use polymorphism to create an object of type IQuittable and call the Quit() method on it.
            IQuittable quittable = new Employee();
            quittable.Quit();


            Console.ReadLine();
        }
    }
}
