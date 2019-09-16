﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndInterfaceExercise
{
    public class Employee : Person, IQuittable
    {
        public int Id { get; set; }

        //Overriding == operator to compare two employee's ID's
        public static bool operator == (Employee employee1, Employee employee2)
        {
            if (employee1.Id == employee2.Id)
                return true;
            else
                return false;
        }
        //Must have pair of == and != when overriding ==
        public static bool operator != (Employee employee1, Employee employee2)
        {
            if (employee1.Id != employee2.Id)
                return true;
            else
                return false;
        }



        //Quit method from IQuittable interface
        public void Quit()
        {
            Console.WriteLine("This employee has quit.");
        }
    }
}
