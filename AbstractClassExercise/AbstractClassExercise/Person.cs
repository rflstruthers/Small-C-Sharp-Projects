using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExercise
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //method to be implemented in another class
        public abstract void SayName();
        
    }
}
