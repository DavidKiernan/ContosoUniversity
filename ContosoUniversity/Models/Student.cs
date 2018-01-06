using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; } // PK

        [Display(Name = "Last Name"), StringLength(50, MinimumLength = 1), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string LastName { get; set; }
        [Required, Display(Name = "First Name"),RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"),StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date), Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}", ApplyFormatInEditMode = true)] // specified formatting should also be applied when the value is displayed in a text box for editing
        public DateTime EnrollmentDate { get; set; }


        [Display(Name = "Full Name")] // Calculated property
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        public virtual ICollection<Enrollment> Enrollments { get; set; } // Nav Property, hold other entities that are related to this entity.
                                                                         // Nav properties are typically defined as virtual so that they can take advantage of certain EF functionality such as lazy loading. 
    }
}