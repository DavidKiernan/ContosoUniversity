namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; } // PK uses "classname" ID pattern
        public int CourseID { get; set; } // FK
        public int StudentID { get; set; }
        public Grade? Grade { get; set; } // The "?" indicates Grade propery is nullable ( isn't known or hasn't been assigned yet)

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}