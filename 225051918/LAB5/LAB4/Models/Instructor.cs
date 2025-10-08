using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB4.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Last Name can only contain letters, spaces, hyphens, and apostrophes")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First/Middle Name is required")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "First/Middle Name can only contain letters, spaces, hyphens, and apostrophes")]
        [Display(Name = "First/Middle Name")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "Hire Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        [CustomValidation(typeof(Instructor), "ValidateHireDate")]
        public DateTime HireDate { get; set; }

        [StringLength(100, ErrorMessage = "Office location cannot exceed 100 characters")]
        [Display(Name = "Office Location")]
        public string Office { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public static ValidationResult ValidateHireDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Today)
                return new ValidationResult("Hire Date cannot be in the future");
            if (date < DateTime.Today.AddYears(-70))
                return new ValidationResult("Hire Date cannot be more than 70 years ago");
            return ValidationResult.Success;
        }
    }
}
