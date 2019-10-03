namespace CodeFirstEfExercise.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        //EnrollmentID will be primary key
        public int EnrollmentID { get; set; }
        //courseID is a foreign key, corresponding to Course
        public int CourseID { get; set; }
        //StudentID is foreign key, corresponding to Student
        public int StudentID { get; set; }
        // ? after Grade means that it is nullable
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}