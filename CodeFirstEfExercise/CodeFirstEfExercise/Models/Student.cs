using System;
using System.Collections.Generic;

namespace CodeFirstEfExercise.Models
{
    public class Student
    {
        //ID becomes the primary key in the table
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        //Navigation property
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}