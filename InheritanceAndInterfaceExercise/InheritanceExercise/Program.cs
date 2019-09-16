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
            //Instantiating the Employee class twice with ID values
            Employee employee1 = new Employee() { Id = 001 };
            Employee employee2 = new Employee() { Id = 002 };

            //using the overloaded == operator to compare two different employee objects.
            if (employee1.Id == employee2.Id)
            {
                Console.WriteLine("The ID numbers match.");
            }
            else
            {
                Console.WriteLine("The ID numbers do not match.");
            }

            ////Instatiating Employee class with first and last name values
            //Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };

            ////calling superclass method SayName() on employee object
            //employee.SayName();

            ////Use polymorphism to create an object of type IQuittable and call the Quit() method on it.
            //IQuittable quittable = new Employee();
            //quittable.Quit();


            Console.ReadLine();
        }
    }
}
