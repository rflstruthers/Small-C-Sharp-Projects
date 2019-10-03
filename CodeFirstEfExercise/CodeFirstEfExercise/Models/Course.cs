using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEfExercise.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        //The Enrollments property is a navigation property. 
        //A Course entity can be related to any number of Enrollment entities.
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}