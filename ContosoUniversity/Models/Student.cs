using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; } // PK
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } // Nav Property, hold other entities that are related to this entity.
                                                                         // Nav properties are typically defined as virtual so that they can take advantage of certain EF functionality such as lazy loading. 
    }
}