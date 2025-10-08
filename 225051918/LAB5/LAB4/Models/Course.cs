using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB4.Models
{
    public class Course
    {
        [Required(ErrorMessage = "Course ID is required")]
        [Range(1, 9999, ErrorMessage = "Course ID must be between 1 and 9999")]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be 3-100 characters")]
        [Display(Name = "Course Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Credits is required")]
        [Range(1, 6, ErrorMessage = "Credits must be between 1 and 6")]
        public int Credits { get; set; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }

    }
}
