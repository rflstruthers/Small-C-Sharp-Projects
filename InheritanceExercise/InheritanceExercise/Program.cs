using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InheritanceAndInterfaceExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask user for a number, log that number in a text file, read the number back to the user from the text file
            Console.WriteLine("Please enter an employee ID number: ");
            string id = Console.ReadLine();
            using (StreamWriter file = new StreamWriter(@".\log.txt", true))
            {
                file.WriteLine(id);
            }
            using (StreamReader file = new StreamReader(@".\log.txt", true))
            {
                Console.WriteLine(file.ReadToEnd());
            }




            ////Creating 10 employee objects with names and ID numbers
            //Employee employee1 = new Employee() { FirstName = "Joe", LastName = "Smith", Id = 001};
            //Employee employee2 = new Employee() { FirstName = "Sally", LastName = "Jones", Id = 002 };
            //Employee employee3 = new Employee() { FirstName = "Ralph", LastName = "Rodgers", Id = 003 };
            //Employee employee4 = new Employee() { FirstName = "Joe", LastName = "Green", Id = 004 };
            //Employee employee5 = new Employee() { FirstName = "Bob", LastName = "Allen", Id = 005 };
            //Employee employee6 = new Employee() { FirstName = "Murphy", LastName = "Palmer", Id = 006 };
            //Employee employee7 = new Employee() { FirstName = "Steve", LastName = "Stevenson", Id = 007 };
            //Employee employee8 = new Employee() { FirstName = "Patty", LastName = "Newman", Id = 008 };
            //Employee employee9 = new Employee() { FirstName = "Shirley", LastName = "Kipling", Id = 009 };
            //Employee employee10 = new Employee() { FirstName = "Greg", LastName = "Old", Id = 010 };

            ////Add all employees to a list
            //List<Employee> employees = new List<Employee>
            //{
            //    employee1,
            //    employee2,
            //    employee3,
            //    employee4,
            //    employee5,
            //    employee6,
            //    employee7,
            //    employee8,
            //    employee9,
            //    employee10
            //};

            ////loop through list of employees and add all employees named "Joe" to a new list
            ////Using foreach
            //foreach (Employee employee in employees)
            //{
            //    if (employee.FirstName == "Joe")
            //    {
            //        List<Employee> foreachJoes = new List<Employee>();
            //        foreachJoes.Add(employee);
            //    }
            //}

            ////loop through list of employees and add all employees named "Joe" to a new list
            ////Using lambda function
            //List<Employee> lambdaJoes = employees.Where(name => name.FirstName == "Joe").ToList();

            ////loop through list of employees and add all employees with an Id greater than 5 to a new list
            ////Using lambda function
            //List<Employee> idOverFive = employees.Where(id => id.Id > 5).ToList();



            ////instantiating an Employee object with type string as it's generic parameter
            //Employee<String> employee = new Employee<String>();

            ////initializing list
            ////adding strings to Things list
            //employee.Things = new List<string>
            //{
            //    "Manager",
            //    "Assistant Manager",
            //    "Intern",
            //    "Receptionist",
            //    "Contract Worker",
            //    "Head of Human Recources"
            //};

            ////instantiating an Employee object with type int as it's generic parameter
            //Employee<int> employee1 = new Employee<int>();

            ////initializing list
            ////adding ints to Things list
            //employee1.Things = new List<int>
            //{
            //    9,
            //    7,
            //    3,
            //    5,
            //    5,
            //    8
            //};

            ////loop printing all things to console
            //for (int i = 0; i < employee.Things.Count; i++)
            //{
            //    Console.WriteLine("Position: " + employee.Things[i]);
            //    Console.WriteLine("Pay Level: " + employee1.Things[i] + "\n");

            //}



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
