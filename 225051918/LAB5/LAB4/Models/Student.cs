using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB4.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be 2-50 chars")]
        [RegularExpression(@"^[\p{L}' \-]+$", ErrorMessage = "Only letters, spaces, hyphens and apostrophes allowed")]
        [MaxWords(10, ErrorMessage = "Maximum 10 words")]
        [NotEqual("FirstMidName", ErrorMessage = "Last name and First/Middle name cannot be the same")]
        public string LastName { get; set; }

        [Display(Name = "First/Middle Name")]
        [Required(ErrorMessage = "First/Middle name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First/Middle name must be 2-50 chars")]
        [RegularExpression(@"^[\p{L}' \-]+$", ErrorMessage = "Only letters, spaces, hyphens and apostrophes allowed")]
        [MaxWords(10, ErrorMessage = "Maximum 10 words")]
        public string FirstMidName { get; set; }

        [Display(Name = "Enrollment Date")]
        [Required(ErrorMessage = "Enrollment date is required")]
        [DateRange(2010, ErrorMessage = "Enrollment date must be between 01/01/2010 and today")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}