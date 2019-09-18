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
            //instantiating an Employee object with type string as it's generic parameter
            Employee<String> employee = new Employee<String>();

            //initializing list
            //adding strings to Things list
            employee.Things = new List<string>
            {
                "Manager",
                "Assistant Manager",
                "Intern",
                "Receptionist",
                "Contract Worker",
                "Head of Human Recources"
            };

            //instantiating an Employee object with type int as it's generic parameter
            Employee<int> employee1 = new Employee<int>();

            //initializing list
            //adding ints to Things list
            employee1.Things = new List<int>
            {
                9,
                7,
                3,
                5,
                5,
                8
            };

            //loop printing all things to console
            for (int i = 0; i < employee.Things.Count; i++)
            {
                Console.WriteLine("Position: " + employee.Things[i]);
                Console.WriteLine("Pay Level: " + employee1.Things[i] + "\n");

            }



            ////Instantiating the Employee class twice with ID values
            //Employee employee1 = new Employee() { Id = 001 };
            //Employee employee2 = new Employee() { Id = 002 };

            ////using the overloaded == operator to compare two different employee objects.
            //if (employee1.Id == employee2.Id)
            //{
            //    Console.WriteLine("The ID numbers match.");
            //}
            //else
            //{
            //    Console.WriteLine("The ID numbers do not match.");
            //}



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
