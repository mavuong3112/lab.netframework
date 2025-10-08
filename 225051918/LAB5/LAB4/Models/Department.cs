using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB4.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Department name must be 2-100 characters")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Budget is required")]
        [Range(0, 999999999.99, ErrorMessage = "Budget must be between 0 and 999,999,999.99")]
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Department), "ValidateStartDate")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Administrator (Instructor ID)")]
        public int? InstructorID { get; set; }

        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public static ValidationResult ValidateStartDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Today)
                return new ValidationResult("Start Date cannot be in the future");
            if (date < DateTime.Today.AddYears(-100))
                return new ValidationResult("Start Date cannot be more than 100 years ago");
            return ValidationResult.Success;
        }
    }
}
