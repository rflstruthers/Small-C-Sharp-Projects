using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingExercisePart2
{
    //custom exception class
    public class RejectionException : Exception
    {
        //constructors, inherits base constructor (from Exception class)
        public RejectionException()
            : base() { }

        public RejectionException(string message)
            : base(message) { }
    }
}
